var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/exchange", async (HttpContext context) =>
{

    string date = "28.12.2015";
    string currency = "USD";

    //string date = context.Request.Query["date"].ToString();
    //string currency = context.Request.Query["currency"].ToString();

    string apiUrl = $"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt?date={date}";

    try
    {
        using (HttpClient client = new HttpClient())
        {
            string content = await client.GetStringAsync(apiUrl);

            string[] lines = content.Split('\n');

            string exchangeRate = "";
            foreach (string line in lines)
            {
                if (line.Contains(currency))
                {
                    string[] parts = line.Split('|');
                    exchangeRate = parts[parts.Length - 1];
                    break;
                }
            }

            if (exchangeRate != null)
            {
                await context.Response.WriteAsync($"Exchange rate for {currency} on {date}: {exchangeRate}");
            }
            else
            {
                await context.Response.WriteAsync($"Exchange rate not found for {currency} on {date}");
            }
        }
    }
    catch (Exception err)
    {
        await context.Response.WriteAsync($"There was an error fetching exchange rates: {err.Message}");
    }
});

app.Run();