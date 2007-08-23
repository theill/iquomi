#region Using directives

using System;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;
using System.Reflection.Emit;
using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Api;

#endregion

namespace Commanigy.Iquomi.Utility {
	/// <summary>
	/// Summary description for PackageAssembly.
	/// </summary>
	public class PackageAssembly {
		private PackageItem[] items_;

		public PackageAssembly(PackageItem[] items) {
			items_ = items;
		}

		public System.Reflection.Assembly CreateAssembly() {
			CompilerParameters compparams = new CompilerParameters();
			compparams.GenerateExecutable = false;
			compparams.OutputAssembly="c:\\mySample.dll";
			compparams.ReferencedAssemblies.Add("System.dll");

			string[] files = new string[items_.Length];
			for (int i = 0; i < items_.Length; i++) {
				files[i] = "c:\\tmp_" + i;
				FileStream fs = File.Create(files[i]);
				byte[] bytes = (byte[])items_[i].Data;
				fs.Write(bytes, 0, bytes.Length);
				fs.Close();
			}

			// Get the current application domain for the current thread.
			AppDomain myCurrentDomain = AppDomain.CurrentDomain;
			AssemblyName myAssemblyName = new AssemblyName();
			myAssemblyName.Name = "TempAssembly";

			// Define a dynamic assembly in the current application domain.
			AssemblyBuilder myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
				(myAssemblyName, AssemblyBuilderAccess.RunAndSave);

			myAssemblyBuilder.DefineDynamicModule("asdf", "dd", true);
			return null;
/*
			CSharpCodeProvider cscp = new CSharpCodeProvider();
			ICodeCompiler cscompiler = cscp.CreateCompiler();
			CompilerResults compresult = cscompiler.CompileAssemblyFromFileBatch(compparams, files);
			if ( compresult == null || compresult.Errors.Count > 0 ) {
				for( int i=0; i<compresult.Output.Count; i++ )                
					Console.WriteLine( compresult.Output[i] );
				for( int i=0; i<compresult.Errors.Count; i++ )                
					Console.WriteLine( i.ToString() + ": " + compresult.Errors[i].ToString() );

			}
			return compresult.CompiledAssembly;
*/
		}

	}
}
