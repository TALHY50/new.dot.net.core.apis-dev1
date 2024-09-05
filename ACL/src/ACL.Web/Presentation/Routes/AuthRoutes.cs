namespace ACL.Web.Presentation.Routes;

public class AuthRoutes
{
    public const string CreateJwtTokenMethod = "POST";
    public const string CreateJwtTokenName = "create_jwt_token";
    public const string CreateJwtTokenTemplateTemplate = "/auth/jwt/token";
    
    public const string RegisterMethod = "POST";
    public const string RegisterName = "register_user";
    public const string RegisterTemplate = "/auth/register";
    
    public const string LoginMethod = "POST";
    public const string LoginName = "user_login";
    public const string LoginTemplate = "/auth/login";

    
    public const string ConfirmEmailMethod = "POST";
    public const string ConfirmEmailName = "confirm_email";
    public const string ConfirmEmailTemplate = "/auth/confirm-email";
}