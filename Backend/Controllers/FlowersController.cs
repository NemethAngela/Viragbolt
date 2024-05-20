using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=viragbolt";

        //�sszes vir�g lek�rdez�se
        [HttpGet]
        public IActionResult GetViragok()
        {
            List<Aruk> listViragok = new List<Aruk>();   //lista l�trehoz�sa modell oszt�ly alapj�n listViragok n�ven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lek�rdez�s db-b�l:
            string query = "SELECT a.id, a.nev, a.kategoriaId, a.leiras, a.keszlet, a.ar, a.kepUrl, k.nev FROM aruk a INNER JOIN kategoriak k ON a.kategoriaId = k.id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Am�g vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int kategoriaId = reader.GetInt32(2);
                string leiras = reader.GetString(3);
                int keszlet = reader.GetInt32(4);
                int ar = reader.GetInt32(5);
                string kepUrl = reader.GetString(6);
                string kategoriaNev = reader.GetString(7);
                //oszt�ly neve:
                Aruk viragok = new Aruk()
                {
                    Id = id,
                    Nev = nev,
                    KategoriaId = kategoriaId,
                    Leiras = leiras,
                    Keszlet = keszlet,
                    Ar = ar,
                    KepUrl = kepUrl,
                    Kategoria = new Kategoriak()  //ez az oszt�ly a Kategoria t�bl�b�l az id �s a nev param�ter
                    {
                        Id = kategoriaId,
                        Nev = kategoriaNev
                    }
                };
                listViragok.Add(viragok);
            }

            connection.Close();

            return Ok(listViragok);
        }

        //vir�g lek�rdez�se Id alapj�n
        [HttpGet("viragId")]
        public IActionResult GetViragokById(int viragId)
        {
            List<Aruk> listViragok = new List<Aruk>();   //lista l�trehoz�sa modell oszt�ly alapj�n listViragok n�ven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lek�rdez�s db-b�l:
            string query = "SELECT a.id, a.nev, a.kategoriaId, a.leiras, a.keszlet, a.ar, a.kepUrl, k.nev FROM aruk a INNER JOIN kategoriak k ON a.kategoriaId = k.id WHERE a.id = @id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", viragId);

            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Am�g vannak sorok a resultban, beolvassa
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);
                int kategoriaId = reader.GetInt32(2);
                string leiras = reader.GetString(3);
                int keszlet = reader.GetInt32(4);
                int ar = reader.GetInt32(5);
                string kepUrl = reader.GetString(6);
                string kategoriaNev = reader.GetString(7);
                //oszt�ly neve:
                Aruk viragok = new Aruk()
                {
                    Id = id,
                    Nev = nev,
                    KategoriaId = kategoriaId,
                    Leiras = leiras,
                    Keszlet = keszlet,
                    Ar = ar,
                    KepUrl = kepUrl,
                    Kategoria = new Kategoriak()  //ez az oszt�ly a Kategoria t�bl�b�l az id �s a nev param�ter
                    {
                        Id = kategoriaId,
                        Nev = kategoriaNev
                    }
                };
                listViragok.Add(viragok);
            }

            connection.Close();

            if (listViragok.Count() > 0)    // megn�zz�k, van-e az a vir�g
                return Ok(listViragok);

            return NotFound("error: A vir�g nem tal�lhat�");
        }

        //lek�rdezi egy vir�g nev�t �s le�r�s�t db-b�l azonos�t� alapj�n
        [HttpGet("{viragId}/details")]
        public IActionResult GetViragNevLeiras(int viragId)
        {
            List<Virag> listVirag = new List<Virag>();   //lista l�trehoz�sa modell oszt�ly alapj�n listVirag n�ven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lek�rdez�s db-b�l:
            string query = "SELECT id, nev, leiras FROM aruk WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", viragId);    //itt csak egy lehet

            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Am�g vannak sorok a resultban, beolvassa
            {
                //oszt�ly neve:
                Virag viragok = new Virag()
                {
                    Id = reader.GetInt32(0),
                    Nev = reader.GetString(1),
                    Leiras = reader.GetString(2)
                };
                listVirag.Add(viragok);
            }

            connection.Close();

            if (listVirag.Count() > 0)    // megn�zz�k, van-e az a vir�g
                return Ok(listVirag);

            return NotFound("error: A vir�g nem tal�lhat�");
        }


        //�j vir�g hozz�ad�sa adatb�zishoz
        [HttpPost]
        public IActionResult CreateVirag([FromBody] Aruk virag)
        {
            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (virag == null ||
                virag.Nev == null ||
                virag.KategoriaId <= 0 ||
                virag.Leiras == null ||
                virag.Keszlet <= 0 ||
                virag.Ar <= 0 ||
                virag.KepUrl == null)
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO aruk (nev, kategoriaId, leiras, keszlet, ar, kepUrl) VALUES (@nev, @kategoriaId, @leiras, @keszlet, @ar, @kepUrl)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@nev", virag.Nev);
            cmd.Parameters.AddWithValue("@kategoriaId", virag.KategoriaId);
            cmd.Parameters.AddWithValue("@leiras", virag.Leiras);
            cmd.Parameters.AddWithValue("@keszlet", virag.Keszlet);
            cmd.Parameters.AddWithValue("@ar", virag.Ar);
            cmd.Parameters.AddWithValue("@kepUrl", virag.KepUrl);


            cmd.ExecuteNonQuery();  //long t�pus sz�ks�ges a visszat�rt-hez
            long insertedViragId = cmd.LastInsertedId;  //LastInsertedId-el k�rem vissza az id-t, amit AutoIncrement-el hoz l�tre

            connection.Close();

            return Created("id", insertedViragId);
        }

        // vir�g m�dos�t�sa
        [HttpPut]
        public IActionResult UpdateVirag([FromBody] Aruk virag)            
        {
            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (virag == null ||
                virag.Id <= 0 ||
                virag.Nev == null ||
                virag.KategoriaId <= 0 ||
                virag.Leiras == null ||
                virag.Keszlet <= 0 ||
                virag.Ar <= 0 ||
                virag.KepUrl == null)
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "UPDATE aruk SET nev = @nev, kategoriaId = @kategoriaId, leiras = @leiras, keszlet = @keszlet, ar = @ar, kepUrl = @kepUrl  WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@id", virag.Id);
            cmd.Parameters.AddWithValue("@nev", virag.Nev);
            cmd.Parameters.AddWithValue("@kategoriaId", virag.KategoriaId);
            cmd.Parameters.AddWithValue("@leiras", virag.Leiras);
            cmd.Parameters.AddWithValue("@keszlet", virag.Keszlet);
            cmd.Parameters.AddWithValue("@ar", virag.Ar);
            cmd.Parameters.AddWithValue("@kepUrl", virag.KepUrl);

            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        //vir�g t�rl�se
        [HttpDelete]
        public IActionResult DeleteVirag(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM aruk WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 0)
                return NotFound(result);

            return Ok();
        }
    }
}