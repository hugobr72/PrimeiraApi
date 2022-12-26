
using PrimeiraApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrimeiraApi.Services {
    public class UserServices {
        public ListUsers getServices() {
            try {
                string query = "select * from users";
                Connect connect = new Connect();
                DataTable data = connect.Query(query);
                UserModel user = new UserModel();
                List<UserModel> List = new List<UserModel>();
                ListUsers Users = new ListUsers();
                foreach (DataRow row in data.Rows) {
                    UserModel User = new UserModel();
                    User.Nome = row["name"].ToString();
                    User.Sobrenome = row["sobrenome"].ToString();
                    User.Email = row["email"].ToString();
                    User.Senha = row["senha"].ToString();
                    User.Id = int.Parse(row["id"].ToString());
                    List.Add(User);
                }
                Users.users = List;
                return Users;
            }
            catch (Exception e) {
                return null;
            }
        }

            public UserModel? putServices(int id){
                UserModel User = new UserModel();
                try {
                string query = "select * from users where id = " + id;
                Connect connect = new Connect();
                DataTable data = connect.Query(query);

                foreach (DataRow row in data.Rows) {                
                    User.Nome = row["name"].ToString();
                    User.Sobrenome = row["sobrenome"].ToString();
                    User.Email = row["email"].ToString();
                    User.Senha = row["senha"].ToString();
                    User.Id = int.Parse(row["id"].ToString());
                    User.idade = int.Parse(row["age"].ToString());
                }

                return User;
                  }catch(Exception e) {
                   return null;

                }
            }

        public UserModel? PostServices(UserModel user) {
            UserModel newUser = new UserModel();
            try {
                string query = @"insert into users values( '" + 
                        user.Nome + "', '" + user.Sobrenome 
                    + "', " + user.idade + ", '" + user.Email + "', '" + user.Senha + "')";
                Connect connect = new Connect();
                DataTable data = connect.Query(query);

                if (data.Rows.Count > 0) {
                foreach (DataRow row in data.Rows) {
                    newUser.Nome = row["name"].ToString();
                    newUser.Sobrenome = row["sobrenome"].ToString();
                    newUser.Email = row["email"].ToString();
                    newUser.Senha = row["senha"].ToString();
                    newUser.Id = int.Parse(row["id"].ToString());
                    newUser.idade = int.Parse(row["age"].ToString());
                }

                }

                return newUser;
            }
            catch (Exception e) {
                return null;

            }
        }
        public bool? DelServices(int id) {
            try {
                string query = "alter table users drop collumn where id = " + id;
                Connect connect = new Connect();
                DataTable data = connect.Query(query);

                return true;
            }
            catch (Exception e) {
                return null;

            }
        }


    }
}
