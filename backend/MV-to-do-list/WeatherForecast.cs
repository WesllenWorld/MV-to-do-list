//vestigio do padrão do web api; não afetará o teste técnico, caso o candidato que vos escreve tenha esquecido de remover

namespace MV_to_do_list
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
