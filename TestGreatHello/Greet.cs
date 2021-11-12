using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestGreatHello
{
    public class Greet : IGreetHello
    {
        private static string[] SplitComma(string sign, string[] names)
        {
            List<string> list = new List<string>();
            var stringEsc = names?.Where(x => x.Contains("\"")).ToArray();
            if (!stringEsc.Any(x => x.Contains(sign) && stringEsc != null))
            {
                var comma = names?.Where(x => x.Contains(sign)).ToArray();
                names = names?.Except(comma).ToArray();
                return names?.Concat(comma.SelectMany(x => x.Split(sign))).ToArray();
            }
            else
            { 
                if (stringEsc.Any(x => x.Contains(sign)))
                {
                    var stringhepulite = stringEsc.Except(stringEsc).ToArray();
                    var newString = stringEsc[0].Replace("\"", string.Empty);
                    if (stringEsc.Any(x => x.Contains(sign)))
                    {
                        list.Add(names[0]);
                        list.Add(newString);
                    }
                }
                return list.ToArray();
            }
        }
        public string GreetHello(params string[] names)
        {

            if (names == null)
                return "Hello, my friend.";

            names = SplitComma(", ", names);

            if (names.Length == 1)
                return names[0] == names[0].ToUpper() ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.";

            if (names.Length == 2)
                return $"Hello, {names[0]} and {names[1]}.";

            var nameUpp = names.Where(x => x.All(char.IsUpper)).ToList();
            var nameDown = names.Except(nameUpp).ToList();

            var result = string.Concat("Hello, ", string.Join(", ", nameDown.Where(x => x != nameDown.Last())), " and ", nameDown.Last(), ".");

            if (nameUpp.Any())
                return string.Concat(result, " AND HELLO ", string.Join(", ", nameUpp.Select(x => x)), "!");
            else if (names.Any(x => x.Contains(",")))
            {
                List<string> lista = new List<string>();
                foreach (var tmp in names)
                {
                    lista.Add(tmp);
                    if (tmp.Contains(","))
                    {
                        var splitted = tmp.Split(",");
                        foreach (var split in splitted)
                        {
                            lista.Add(split);
                        }
                    }
                }
                return string.Concat(lista.Select(x => x));
            }
            return result;
        }
    }
}

////return result;
////var appoggio = "Hello, ";
////if (names == null)
////    return "Hello, my friend.";
////if (names.Length == 1)
////    return names[0] == names[0].ToUpper() ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.";
////if (names.Length == 2)
////    return $"Hello, {names[0]} and {names[1]}.";
////if (names.Any(x => string.Equals(x, x.ToUpper())) && names.Length > 2)
////{
////    var upperNames = names.Where(x => string.Equals(x, x.ToUpper()));
////    List<string> listMinuscoli = new List<string>();
////    foreach (var maiuscoli in upperNames)
////    {
////        foreach (var minuscoli in names)
////        {
////            if (minuscoli != maiuscoli)
////            {
////                listMinuscoli.Add(minuscoli);
////            }
////        }
////    }
////    return string.Concat("Hello, " + string.Join(" and ", listMinuscoli) + $". AND HELLO {upperNames.Select(x => x).First()}!");
////}
////else if (names.Length > 2)
////{
////    string last = names.Last();
////    var otherName = names.Where(x => x != last); // scorre tutto e tranne l'ultimo elemento creando un un Ienumerable
////    return string.Concat("Hello, " + string.Join(", ", otherName) + ", and " + last + "."); //string Join ti crea uno stringone e gli puoi interpolare anche qualche carattere, tipo le virgole.
////}
////else if (names.Any(x => x.Contains(",")))
////{
////    List<string> lista = new List<string>();
////    foreach (var tmp in names)
////    {
////        lista.Add(tmp);
////        if (tmp.Contains(","))
////        {
////            var splitted = tmp.Split(",");
////            foreach (var split in splitted)
////            {
////                lista.Add(split);
////            }
////        }
////    }
////    string last = names.Last();
////    var otherName = lista.Where(x => x != last);
////    return string.Concat("Hello, " + string.Join(", otherName) + ",  " + last + ".");
////}
//return appoggio;
//public string GreetHello(params string[] names) => names == null ?
//    "Hello, my friend." : names.Length > 1 ?
//    $"Hello, {names[0]} and {names[1]}." :
//    names[0] == names[0].ToUpper() ?
//    $"HELLO {names[0]}!" : $"Hello, {names[0]}.";

//public string GreetHello(params string[] names)
//{

//    var appoggio = "Hello, ";
//    var lunghezza = names.Length;
//    for(int i = 0; i < lunghezza-1; i++)
//    {
//        appoggio = appoggio + names[i] +", ";
//    }
//    return $"{appoggio}and {names[lunghezza-1]}.";
//}