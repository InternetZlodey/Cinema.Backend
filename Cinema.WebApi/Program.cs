using Cinema.Application.Common.Mappings;
using Cinema.Application.Interfaces;
using Cinema.Persinstence;
using System.Reflection;
using Cinema.Application;

//������� ������
var builder = WebApplication.CreateBuilder(args);

//������������ AutoMapper ����� �� ��������������� ��� ������ ��� ��������
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMapingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMapingProfile(typeof(ICinemaDbContext).Assembly));
});

//���������� NewtonsoftJson �� Micrososft
//��������� ���������� object-������������ (��������� � �������� ������ .Include<> ��� ������������� ������ ����� ���������)
//(����� ���� ��������������� � ��������� JsonIgnore � ������ � ����������� Fluent Api)
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//��������� ���� ���������� �������
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();

//�������� ������� �� ����� � ��� (aka ��������� ��� �������,� ���������� ��� ������ �� ����)
builder.Services.AddCors(options =>
                         options.AddPolicy("AllowAll", policy =>
                         {
                             policy.AllowAnyHeader();
                             policy.AllowAnyMethod();
                             policy.AllowAnyOrigin();
                         })
);

//�������� ����������
var app = builder.Build();

//������� � ���������� ��� �� �������
using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        //������� �� � �������������� �� ���
        var context = serviceProvider.GetRequiredService<CinemaDbContext>();
        //������������� ��� �� ��������� ���� �� �������� ��
        DbInitializer.Initialize(context);
    }
    //�������������� ��������������
    catch (Exception ex)
    {

    }
}

//��������� ��������
app.UseRouting();
app.UseHttpsRedirection();

//��������� ����,������� �������� ������ ( � ���������� �� ���� ��� ������ :) )
app.UseCors("AllowAll");

app.MapControllers();

app.Run();