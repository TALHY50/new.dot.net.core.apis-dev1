namespace ACL.Web.Presentation.Routes;

public class AuthRoutes
{
    public const string CreateJwtTokenMethod = "POST";
    public const string CreateJwtTokenName = "create_jwt_token";
    public const string CreateJwtTokenTemplateTemplate = "/v1/auth/jwt/token";
    
    public const string RegisterMethod = "POST";
    public const string RegisterName = "register_user";
    public const string RegisterTemplate = "/v1/auth/register";
    
    public const string LoginMethod = "POST";
    public const string LoginName = "user_login";
    public const string LoginTemplate = "/v1/auth/login";

    
    public const string ConfirmEmailMethod = "POST";
    public const string ConfirmEmailName = "confirm_email";
    public const string ConfirmEmailTemplate = "/v1/auth/confirm-email";
}