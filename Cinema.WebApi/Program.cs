using Cinema.Application.Common.Mappings;
using Cinema.Application.Interfaces;
using Cinema.Persinstence;
using System.Reflection;
using Cinema.Application;

//Создаем билдер
var builder = WebApplication.CreateBuilder(args);

//Конфигурирем AutoMapper чтобы он идентифицировал все модели при маппинге
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMapingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMapingProfile(typeof(ICinemaDbContext).Assembly));
});

//Библиотека NewtonsoftJson от Micrososft
//Поддержка цикличного object-итерирования (поддержка в запросах метода .Include<> для организования связей между таблицами)
//(Можно было воспользоваться и свойством JsonIgnore в связке с аннотациями Fluent Api)
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//Добавляем наши написанные сервисы
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();

//Получаем запросы от всего и вся (aka отключаем все фильтры,в продакшене так делать не надо)
builder.Services.AddCors(options =>
                         options.AddPolicy("AllowAll", policy =>
                         {
                             policy.AllowAnyHeader();
                             policy.AllowAnyMethod();
                             policy.AllowAnyOrigin();
                         })
);

//Собираем приложение
var app = builder.Build();

//Создаем и убеждаемся что БД создана
using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        //Получем БД и инициализируем ее тут
        var context = serviceProvider.GetRequiredService<CinemaDbContext>();
        //Инициализатор так же проверяет была ли получена БД
        DbInitializer.Initialize(context);
    }
    //Непредвиденное обстоятельство
    catch (Exception ex)
    {

    }
}

//Добавляем свойства
app.UseRouting();
app.UseHttpsRedirection();

//Применяем Корс,который объявили сверху ( В продакшене не надо так делать :) )
app.UseCors("AllowAll");

app.MapControllers();

app.Run();