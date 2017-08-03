using System.Reflection;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCulture("")]
[assembly: AssemblyCompany("CodeStacks")]
[assembly: AssemblyCopyright("Copyright © CodeStacks 2017")]
[assembly: AssemblyTrademark("z.xiaowen@foxmail.com")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.6.1707.19")]
[assembly: AssemblyInformationalVersion("3.6.1707.19")]

#if !PocketPC
[assembly: AssemblyFileVersion("3.6.1707.19")]
#endif