namespace Traversal.Areas.Admin.Models.AppRole
{
    public class AssignRoleViewModel
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public bool RoleExist  { get; set; } //bu rol bu kullanıcıda var mı
    }
}
