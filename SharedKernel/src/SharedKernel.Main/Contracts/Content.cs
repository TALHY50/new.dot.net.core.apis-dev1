namespace SharedKernel.Main.Contracts;

public record Content(
    string Subject = "",
    string ContentTemplateName = "",
    string ContentTemplatePath = "",
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    object ContentTemplateModel = null,
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    string AttachmentInfo = "",
    string Language = "");