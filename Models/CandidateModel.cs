
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class GlobalResponseModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public string Data { get; set; }

    }







public class CandidateModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }            

        public string CallTimeInterval { get; set; }
                
        public string LinkedinUrl { get; set; }
            
        public string GithubUrl { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
    }


}
