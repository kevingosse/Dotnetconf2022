using lldb;
using System.Runtime.InteropServices;

namespace LldbExtension;

public class Plugin
{
    [UnmanagedCallersOnly(EntryPoint = "_ZN4lldb16PluginInitializeENS_10SBDebuggerE")]
    public static unsafe bool PluginInitialize(SBDebugger* debugger)
    {
        var interpreter = debugger->GetCommandInterpreter();

        return true;
    }
}