namespace TakeAway.Comment.Dtos
{
    public class ResultUserCommentDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string CommentDetail { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
