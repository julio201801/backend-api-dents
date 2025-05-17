

using NGsystem.Dents.Core;

namespace NGsystem.Dents.Application.Common;
public class CustomError : CustomErrorCode
{
    public CustomError(string codigo, string mensaje, string validacion) : base(codigo, mensaje, validacion)
    {
    }

}