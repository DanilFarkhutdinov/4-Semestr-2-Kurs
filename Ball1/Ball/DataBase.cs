using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using MySqlConnector;

namespace Ball
{
    internal class DataBase
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        public DataBase()
        {
            this.connection = new MySqlConnection("server=localhost;User ID=root;Password=;database=game");
            this.connection.Open();
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "CREATE TABLE IF NOT EXISTS `Points`(id SERIAL PRIMARY KEY, Color VARCHAR(20), Score INT DEFAULT 0)";
            this.command.CommandText = "ALTER TABLE `Points` AUTO_INCREMENT = 1";
            //this.command.CommandText = "ALTER TABLE `Points` MODIFY COLUMN `Color` VARCHAR(40)";
            this.command.ExecuteNonQuery();
            this.connection.Close();
        }

        public void Insert(string columns, string lines)
        {
            this.connection.Open();
            this.command.CommandText = "INSERT INTO `Points` ("+columns+") VALUES ("+lines+")";
            this.command.ExecuteNonQuery();
            this.connection.Close();
        }
        public int Select(int id)
        {
            this.connection.Open();
            this.command.CommandText = "SELECT `Score` FROM `Points` WHERE id = "+id+"";
            this.command.ExecuteNonQuery();
            int x = 0;
            reader = this.command.ExecuteReader();
            while (reader.Read())
            {
                x = (int)reader.GetInt32(0);
            }
            this.connection.Close();
            return x;
        }
        public void Delete(string name)
        {
            this.connection.Open();
            this.command.CommandText = "DELETE FROM " + name + "";
            this.command.ExecuteNonQuery();
            this.connection.Close();
        }

        public void TableChange(int id)
        {
            this.connection.Open();
            this.command.CommandText = "UPDATE `Points` SET `Score` = `Score` + 1 WHERE id = "+id+"";
            this.command.ExecuteNonQuery();
            this.connection.Close();
        }
    }
}
