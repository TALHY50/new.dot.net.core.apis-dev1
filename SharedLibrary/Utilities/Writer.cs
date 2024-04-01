using System.Text;

namespace SharedLibrary.Utilities;

public class Writer : StringWriter {
    public override Encoding Encoding => Encoding.UTF8;
}