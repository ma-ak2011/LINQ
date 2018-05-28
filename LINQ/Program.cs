using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //芸能人好感度ランキングから名前を借りました。
            var people = new List<Person>
            {
                new Person { Name = "明石家さんま", Age = 63, Sex = Sex.Male, BirthPlace = "東京都"},
                new Person { Name = "阿部寛", Age = 54, Sex = Sex.Male, BirthPlace = "神奈川県"},
                new Person { Name = "マツコ・デラックス", Age = 46, Sex = Sex.Male, BirthPlace = "千葉県"},
                new Person { Name = "内村光良", Age = 54, Sex = Sex.Male, BirthPlace = "熊本県"},
                new Person { Name = "新垣結衣", Age = 30, Sex = Sex.Female, BirthPlace = "神奈川県"},
                new Person { Name = "浅田真央", Age = 28, Sex = Sex.Female, BirthPlace = "東京都"},
                new Person { Name = "綾瀬はるか", Age = 33, Sex = Sex.Female, BirthPlace = "熊本県"}
            };

            Console.WriteLine("最初の一行を取得する"); 
            var first = people.First();
            Console.WriteLine(first);
            
            Console.WriteLine(Environment.NewLine + "男性を取得する");
            var men = people.Where(p => p.Sex == Sex.Male).ToList();

            men.ForEach(Console.WriteLine);
            
            Console.WriteLine(Environment.NewLine + "女性から一人取得する");
            var firstFemale = people.First(p => p.Sex == Sex.Female);

            Console.WriteLine(firstFemale);

            Console.WriteLine(Environment.NewLine + "熊本県出身の人がいるかどうか");
            var existPersonFromKumamoto = people.Any(p => p.BirthPlace == "熊本県");
            Console.WriteLine(existPersonFromKumamoto);

            Console.WriteLine(Environment.NewLine + "全員男性かどうか");
            var areAllMale = people.All(p => p.Sex == Sex.Male);
            Console.WriteLine(areAllMale);

            Console.WriteLine(Environment.NewLine + "年齢で昇順に並べる");
            var orderedByAge = people.OrderBy(p => p.Age).ToList();
            orderedByAge.ForEach(Console.WriteLine);

            Console.WriteLine(Environment.NewLine + "年齢で降順に並べた後、名前で昇順に");
            var orderedByAgeThenByName = people.OrderByDescending(p => p.Age).ThenBy(p => p.Name).ToList();
            orderedByAgeThenByName.ForEach(Console.WriteLine);

            Console.WriteLine(Environment.NewLine + "出身地ごとにグループにして、グループを出身地の県名の順に並べる");
            var groupByAndOrderedBy = people.GroupBy(p => p.BirthPlace).OrderBy(g => g.Key).ToList();
            groupByAndOrderedBy.ForEach(g =>
            {
                Console.WriteLine(g.Key);
                g.ToList().ForEach(Console.WriteLine);
            });

            Console.WriteLine(Environment.NewLine + "年齢だけ一覧にしたい");
            var ages = people.Select(p => p.Age).ToList();
            ages.ForEach(a => Console.WriteLine("//" + a));

            Console.WriteLine(Environment.NewLine + "出身地だけ一覧にして重複を消したい");
            var birthPlaces = people.Select(p => p.BirthPlace).Distinct().ToList();
            birthPlaces.ForEach(p => Console.WriteLine("//" + p));

            Console.WriteLine(Environment.NewLine + "年齢の最小値、最大値、平均値、合計値を取得したい");
            var min = people.Min(p => p.Age);
            Console.WriteLine("//最小値:" + min);

            var max = people.Max(p => p.Age);
            Console.WriteLine("//最大値:" + max);

            var average = people.Average(p => p.Age);
            Console.WriteLine("//平均値:" + average);

            var sum = people.Sum(p => p.Age);
            Console.WriteLine("//合計値:" + sum);

            Console.Read();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public string BirthPlace { get; set; }

        public override string ToString()
        {
            var data =  "//" + Name + " " + Age + "才 " + (Sex == Sex.Male ? "男 " : "女 ") + BirthPlace + "出身";
            return data;
        }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }
}
