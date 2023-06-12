using System.Net.WebSockets;
using System.Text;
using System.Timers;
using WebApplication2.Controllers;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseWebSockets();

app.MapControllers();


System.Timers.Timer timer = new System.Timers.Timer();
timer.Elapsed += new System.Timers.ElapsedEventHandler(test);
timer.AutoReset = true;
timer.Interval = 1000; //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
timer.Start();


app.Run();


async void test(object source, ElapsedEventArgs e)
{
    if (WebSocketsController.webSocket != null && WebSocketsController.webSocket.State == WebSocketState.Open)
    {
        var serverMsg = Encoding.UTF8.GetBytes("OK, test event is fired at: " + DateTime.Now.ToString());
        await WebSocketsController.webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
    }
    Console.WriteLine("OK, test event is fired at: " + DateTime.Now.ToString());

}

//1