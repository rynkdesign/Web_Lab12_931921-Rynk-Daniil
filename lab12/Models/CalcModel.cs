namespace lab12.Models
{
    public class CalcModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string operation { get; set; }

        public string Calc()
        {
            return operation switch
            {
                "+" => $"{X} + {Y} = {X + Y}",
                "-" => $"{X} - {Y} = {X - Y}",
                "*" => $"{X} * {Y} = {X * Y}",
                "/" when Y != 0 => $"{X} / {Y} = {X / Y}",
                "/" when Y == 0 => "Error. Division by zero.",
                _ => "Invalid operation"
            };
        }
    }
}
