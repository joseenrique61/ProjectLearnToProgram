using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class Converter : MonoBehaviour
{
    private static string path = "";

    /// <summary>
    /// Obtiene el bloque de código en el lenguaje especificado.
    /// </summary>
    /// <param name="block">Bloque de código a obtener.</param>
    /// <param name="language">Lenguaje en el que se va a obtener el bloque de código.</param>
    /// <returns>Bloque de código en el lenguaje especificado.</returns>
    private async Task<string> GetFileContent(string block, string language)
    {
        string fileContent = "";
        await Task.Run(() =>
        {
            string file = File.ReadAllText(path);
            JArray jArrayFile = (JArray)JsonConvert.DeserializeObject(file);
            foreach (JObject jobject in jArrayFile.Cast<JObject>())
            {
                string name = (string)jobject["type"];
                if (block == name) 
                {
                    fileContent = (string)jobject[language];
                    break;
                }
            }
        });
        return fileContent;
    }

    /// <summary>
    /// Crea una nueva cadena reemplazada de sentencias con condicionales.
    /// </summary>
    /// <param name="blockType">Tipo de bloque a reemplazar.</param>
    /// <param name="cond">Condicional a reemplazar.</param>
    /// <param name="x">Código a reemplazar.</param>
    /// <param name="language">Lenguaje en el que se va a reemplazar.</param>
    /// <returns>Cadena reemplazada.</returns>
    public async Task<string> WithCond(string blockType, string cond, string x, string language)
    {
        string replaced = "";
        await Task.Run(async () =>
        {
            string plantilla = await GetFileContent(blockType, language);
            replaced = Replace(plantilla, x, "x");
            replaced = Replace(replaced, cond, "cond");
            replaced = await AddTabulation(replaced);
        });
        return replaced;
    }

    /// <summary>
    /// Crea una nueva cadena reemplazada de sentencias de asignación.
    /// </summary>
    /// <param name="blockType">Tipo de bloque a reemplazar.</param>
    /// <param name="name">Nombre a reemplazar.</param>
    /// <param name="x">Código a reemplazar.</param>
    /// <param name="language">Lenguaje en el que se va a reemplazar.</param>
    /// <returns>Cadena reemplazada.</returns>
    public async Task<string> WithName(string blockType, string name, string x, string language)
    {
        string replaced = "";
        await Task.Run(async () =>
        {
            string plantilla = await GetFileContent(blockType, language);
            replaced = Replace(plantilla, x, "x");
            replaced = Replace(replaced, name, "name");
        });
        return replaced;
    }

    /// <summary>
    /// Crea una nueva cadena reemplazada de asignaciones con tamaño de cadena.
    /// </summary>
    /// <param name="blockType">Tipo de bloque a reemplazar.</param>
    /// <param name="name">Nombre a reemplazar.</param>
    /// <param name="cant">Tamaño de la cadena a reemplazar</param>
    /// <param name="x">Código a reemplazar.</param>
    /// <param name="language">Lenguaje en el que se va a reemplazar.</param>
    /// <returns>Cadena reemplazada.</returns>
    public async Task<string> WithCant(string blockType, string name,string cant, string x, string language)
    {
        string replaced = "";
        await Task.Run(async () =>
        {
            string plantilla = await GetFileContent(blockType, language);
            replaced = Replace(plantilla, x, "x");
            replaced = Replace(replaced, name, "name");
            replaced = Replace(replaced, cant, "cant");
        });
        return replaced;
    }

    /// <summary>
    /// Reemplaza el código especificado en el bloque de código.
    /// </summary>
    /// <param name="block">Bloque de código en el que se va a reemplazar.</param>
    /// <param name="toReplace">Bloque de código para reemplazar.</param>
    /// <param name="toPass">Lugar en el que se va a reemplazar.</param>
    /// <returns></returns>
    private string Replace(string block, string toReplace, string toPass)
    {
        string replaced = block.Replace(toPass, toReplace);
        return replaced;
    }

    /// <summary>
    /// Añade cierta tabulación, especificada en la plantilla.
    /// </summary>
    /// <param name="block">Código al que se le va a añadir la tabulación.</param>
    /// <returns>Cadena tabulada e indentada.</returns>
    private async Task<string> AddTabulation(string block)
    {
        string indented = "";
        await Task.Run(() =>
        {
            string[] blockSplitted = block.Split('~');
            foreach (string line in blockSplitted)
            {
                char zero = line[0];
                string line0 = zero.ToString();
                int num = int.Parse(line[0].ToString());
                string tabString = "";
                for (int i = 0; i < num; i++)
                {
                    tabString += "\t";
                }
                string newString = tabString + line.Trim(char.Parse(num.ToString()));
                indented += newString;
            }
        });
        return indented;
    }

    public async void Start()
    {
        string path = $@"{Application.dataPath}\PlantillaBlocks\Plantillas.json";
        Converter.path = path;
        string one = await WithName("if", "cone", "eone", "c#");
    }
}