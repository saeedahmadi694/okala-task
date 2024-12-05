#### 1\. **How long did you spend on the coding assignment? What would you add to your solution if you had more time?**

*   **Time Spent:** I would estimate around 4–5 hours to complete the assignment
    
*   **What I would add:**
    
    *   **Error Handling:** More comprehensive validation mechanisms for API
        
    *   **Logging and Monitoring:** Integration with tools like Serilog and Application Insights for better logging and monitoring.
        

#### 2\. **What was the most useful feature that was added to the latest version of your language of choice?**

*   **Feature:** The introduction of Record in C# 9.
    
*   **Why it’s useful:** Records are immutable by design, making them ideal for data objects that should not change after creation.
    

**Code Snippet:**

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   public record GetCryptoInfoInput(string Base, List? Types)  {      [JsonIgnore]      public string NormalizeBase => Base.ToUpper();  };  // Usage  var request = new CryptoRequest("USD", ["USD","EUR","JUP"]);   `

#### 3\. **How would you track down a performance issue in production? Have you ever had to do this?**

*   **Steps to track performance issues:**
    
    1.  **Log Analysis:** Review application logs for anomalies or high-latency operations.
        
    2.  **Profiling Tools:** Use tools like prometheus and grafana
        
    3.  **Database Profiling:** Investigate slow queries using tools like SQL Profiler or database-specific monitoring tools.
        
    4.  **Benchmark:** For highly concurrent issues, analyze thread dumps to identify potential deadlocks or bottlenecks.
        
*   **Personal Experience:**
    

#### 4\. **What was the latest technical book you have read or tech conference you have been to? What did you learn?**

*   **Book:** _C# 12 in a Nutshell: The Definitive Reference_.
    
    *   **Key Learnings:** List and collections ,c# new features, …
        

#### 5\. **What do you think about this technical assessment?**

#### 6\. **Please, describe yourself using JSON.**

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   {    "name": "Saeed Ahmadi",    "role": "Software Developer",    "skills": ["C#", ".NET Core", "ASP.NET MVC", "RESTful APIs", "Git"],    "experience": "More than 3 years",    "hobbies": ["Reading books", "Cycling", "Playing guitar"]  }   `
