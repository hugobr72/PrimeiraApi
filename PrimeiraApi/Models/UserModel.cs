namespace PrimeiraApi.Models {
    public class UserModel {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public int idade { get; set; }

    }

    public class ListUsers {
        public List<UserModel> users { get; set; }
}
}
