namespace Bank.Api.Middleware;

public class RequestIdMiddleware
{
    private readonly RequestDelegate _next;

    public RequestIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestId = Guid.NewGuid();

        Console.WriteLine($"Middleware: Request {requestId} started");

        await _next(context);

        Console.WriteLine($"Middleware: Request {requestId} finished");
    }
}