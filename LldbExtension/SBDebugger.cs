using LldbExtension;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace lldb;

public unsafe struct SBDebugger
{
    public lldb.SBCommandInterpreter GetCommandInterpreter()
    {
        var address = NativeLibrary.GetExport(NativeLibrary.GetMainProgramHandle(), "lldb.SBDebugger.GetCommandInterpreter");

        var function = (delegate* unmanaged<SBDebugger*, SBCommandInterpreter>)address;

        var self = (SBDebugger*)Unsafe.AsPointer(ref this);

        return function(self);
    }
}