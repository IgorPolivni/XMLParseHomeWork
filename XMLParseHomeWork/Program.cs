using System;
using System.Collections.Generic;
using System.Xml;
using XMLParseHomeWork;

namespace XMLParseLesson
{
    class Program
    {
        public static readonly int ROUTE_ELEMENT_POSITION = 0;

        static void Main(string[] args)
        {
            var itemList = new List<Item>();

            var xmlDocument = new XmlDocument();
            xmlDocument.Load("https://habrahabr.ru/rss/interesting/");
            var RouteElement = xmlDocument.GetElementsByTagName("rss")[ROUTE_ELEMENT_POSITION];
            var channelElements = RouteElement.ChildNodes;

            foreach (XmlElement channel in channelElements)
            {

                foreach (XmlElement element in channel)
                {

                    if (element.Name == "item")
                    {
                        Item item = new Item();

                        foreach (XmlElement elementInItem in element)
                        {
                            switch (elementInItem.Name)
                            {
                                case "title":
                                    item.Title = elementInItem.InnerText;
                                    break;
                                case "link":
                                    item.LInk = elementInItem.InnerText;
                                    break;
                                case "description":
                                    item.Description = elementInItem.InnerText;
                                    break;
                                case "pubDate":
                                    item.PubDate = elementInItem.InnerText;
                                    break;
                            }

                        }
                        itemList.Add(item);

                    }
                }
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();


            xmlDocument = new XmlDocument();
            Student student = new Student()
            {
                FirstName = "Игорь",
                LastName = "Поливин",
                GroupName = "SEP-201",
                Specialty = "Разработчик ПО",
                Ratings = new int[] { 10, 11, 12, 10, 11, 12 }
            };

            var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            xmlDocument.AppendChild(xmlDeclaration);

            var routeElement = xmlDocument.CreateElement("student");
            xmlDocument.AppendChild(routeElement);

            Dictionary<string, string> studentDictionary = new Dictionary<string, string>()
            {
                { "FirstName",student.FirstName},
                { "LastName",student.LastName},
                { "GroupName",student.GroupName},
                { "Specialty",student.Specialty},
            };

            foreach (var dictionaryElement in studentDictionary)
            {
                var property = xmlDocument.CreateElement(dictionaryElement.Key);
                property.InnerText = dictionaryElement.Value;
                routeElement.AppendChild(property);
            }


            var ratings = xmlDocument.CreateElement("Ratings");
            routeElement.AppendChild(ratings);

            //estimation - оценка; Ratings - оценки
            foreach (int estimation in student.Ratings)
            {
                var estimationElement = xmlDocument.CreateElement("estimation");
                estimationElement.InnerText = estimation.ToString();
                ratings.AppendChild(estimationElement);
            }
            xmlDocument.Save("data.xml");


        }
    }
}
