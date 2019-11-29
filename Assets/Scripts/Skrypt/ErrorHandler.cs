
using UnityEngine;
using Skrypt;

public class ErrorHandler : Skrypt.ErrorHandler {

    public ErrorHandler(SkryptEngine engine) : base(engine) {
    }

    public override void FatalError(int index, int line, int column, string msg) {
        throw CreateError(index,line,column,msg);
    }

    public override string ReportError(SkryptException error) {
        Debug.LogError(error);

        return error.ToString();
    }
}
