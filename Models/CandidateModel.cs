

namespace Models
{
    public class GlobalResponseModel<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public string Data { get; set; }

    }





    public class CandidateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CallTimeInterval { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
        public string Comment { get; set; }
    }

}
