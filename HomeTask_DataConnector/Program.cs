
using Npgsql;

var connectionS = "Server = localhost;Port=5432;User Id=postgres;Password = password;Database=butcamp";
var con = new NpgsqlConnection(connectionS);
con.Open();

using var cmd = con.CreateCommand();
    cmd.Connection = con;


//cmd.CommandText = "CREATE TABLE IF NOT EXISTS shopClientPoints(pid int NOT NULL primary key,points int)";
//cmd.CommandText = "INSERT INTO public.shopClientPoints VALUES(1,300),(2,134),(3,321),(4,222),(5,50),(6,0),(7,500)";
//cmd.CommandText = "UPDATE public.shopclientpoints SET points = 20 WHERE points = 0;";
//cmd.CommandText = "DELETE FROM shopclientpoints WHERE points < 300";
//using (NpgsqlDataReader reader = cmd.ExecuteReader())
//    reader.Read();

GetBySubject();


void GetBySubject()
{
    cmd.CommandText = "Select shop.pid,shop.lastname,shop.firstname,shopclientpoints.points From shop INNER JOIN shopclientpoints ON shopclientpoints.pid = shop.pid;";
    NpgsqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Client`s ID {reader[0]}\nName: {reader[1]} {reader[2]} Points = {reader[3]}\n\n");
    }
}





con.Close();