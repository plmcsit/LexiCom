using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Code_Generation
{
    public class OutputInitializer
    {
        public string error = "";
        public void Start(string code) {
            CompilerResults cr = ExecuteCode(code);
            bool pass;
            if (cr.Errors.Count > 0)
            {
                pass = false;
            }
            else
            {
                pass = true;
            }

            if (pass)
            {
                // Display a successful compilation message.
                Console.WriteLine("Source {0} built into {1} successfully.",
                    "Output", cr.PathToAssembly);
                var process = Process.Start(cr.PathToAssembly);
                
                process.WaitForExit();
                process.Close();
            }
            else
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    "Output", cr.PathToAssembly);

                foreach (CompilerError ce in cr.Errors)
                {
                    if (!ce.IsWarning)
                    {
                        error += ce.ErrorText + "\n";
                        Console.WriteLine("  {0}", ce.ToString());
                        Console.WriteLine();
                    }
                }
            }
        }
    
    private CompilerResults ExecuteCode(string code)
        {
            CodeDomProvider provider = null;
            CompilerResults cr = null;
            provider = CodeDomProvider.CreateProvider("CSharp");
            // Select the code provider based on the input file extension.
            
            if (provider != null)
            {

                // Format the executable file name.
                // Build the output assembly path using the current directory
                // and <source>_cs.exe or <source>_vb.exe.

                String exeName = String.Format(@"{0}\{1}.exe",
                    System.Environment.CurrentDirectory, "Output");

                CompilerParameters cp = new CompilerParameters();

                // Generate an executable instead of 
                // a class library.
                cp.GenerateExecutable = true;

                // Specify the assembly file name to generate.
                cp.OutputAssembly = exeName;

                // Save the assembly as a physical file.
                cp.GenerateInMemory = false;

                // Set whether to treat all warnings as errors.
                cp.TreatWarningsAsErrors = false;

                // Invoke compilation of the source file.
                cr = provider.CompileAssemblyFromSource(cp, code);
                
            }
            return cr;
        }
    }
}
