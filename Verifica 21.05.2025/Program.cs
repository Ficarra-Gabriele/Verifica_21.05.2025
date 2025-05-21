List<string>LeggiFile(string p) // Funzione Punto 1
{
    List<string> Lista_Nella_Funzione = File.ReadAllLines(p).ToList<string>();

    Lista_Nella_Funzione.RemoveAt(0);
    return Lista_Nella_Funzione;
}
List<string> FiltraPerConsumo(List<string> Lista_Nella_Funzione) // Funzione Punto 2 e 3
{
    List<string>Famiglie = new List<string>(); 
    foreach (string s in Lista_Nella_Funzione)
    {
        string[] j = s.Split(';');
        if (float.Parse(j[4]) <= 300)
        {
            Famiglie.Add(j[1] + "-" +j[2]+"-" + j[4]);
        }
    }
    return Famiglie;
}
List<string> CalcolaStatistiche(List<string> Lista_Nella_Funzione) // Funzione punto 4
{
    float y = 0;
    float max = 0;
    float tot = 0;
    List<string> Risultati = new List<string>();
    foreach (string s in Lista_Nella_Funzione)
    {
        string[] j = s.Split(';');
        y = y + float.Parse(j[4]);
        if (float.Parse(j[3]) > max)
        {
            max = float.Parse(j[3]);
        }
        tot = y;
    }
    y = y / Lista_Nella_Funzione.Count; 
    foreach(string i in Lista_Nella_Funzione)
    {
        string[] j = i.Split(';');
        if (float.Parse(j[4]) <= 250)
        {
            Risultati.Add(j[1]);
        }
    }
    Console.WriteLine("Consumo medio: " + y);
    Console.WriteLine("Più Componenti: " + max);
    Console.WriteLine("Consumo totale" + tot);
    Console.WriteLine("Famiglie sotto i 250KWh");
    foreach (string f in Risultati)
    {
        Console.WriteLine(f);
    }

    return Risultati;
}
string FilePath1 = "consumi.csv";
List<string> Lista = LeggiFile(FilePath1);

foreach (string f in Lista) 
{
    Console.WriteLine(f); 
}

Console.WriteLine(); // Separatore

List<string> Lista2 = FiltraPerConsumo(Lista);
foreach (string f in Lista2)
{
    Console.WriteLine(f);
}

Console.WriteLine(); // Separatore

CalcolaStatistiche(Lista);
