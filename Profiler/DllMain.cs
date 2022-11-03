using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Profiler;

public unsafe class ClassFactory : IClassFactory
{
    private CorProfilerCallback _callback;

    public IntPtr Object { get; private set; }

    public ClassFactory()
    {
        Object = NativeObjects.IClassFactory.Wrap(this);
    }

    public int QueryInterface(in Guid guid, out IntPtr ptr)
    {
        Console.WriteLine("QueryInterface");
        ptr = IntPtr.Zero;
        return 0;
    }

    public int AddRef()
    {
        Console.WriteLine("AddRef");
        return 1;
    }

    public int Release()
    {
        Console.WriteLine("Release");
        return 1;
    }

    public int CreateInstance(IntPtr outer, in Guid guid, out IntPtr instance)
    {
        Console.WriteLine("CreateInstance");

        _callback = new CorProfilerCallback();

        instance = _callback.Object;
        
        return 0;
    }

    public int LockServer(bool @lock)
    {
        Console.WriteLine("LockServer");
        return 0;
    }
}


public class DllMain
{
    static ClassFactory _classFactory;

    [UnmanagedCallersOnly(EntryPoint = "DllGetClassObject")]
    public static unsafe int DllGetClassObject(Guid* rclsid, Guid* riid, IntPtr* ppv)
    {
        Console.WriteLine("DllGetClassObject");

        _classFactory = new();

        *ppv = _classFactory.Object;

        return 0;
    }
}
