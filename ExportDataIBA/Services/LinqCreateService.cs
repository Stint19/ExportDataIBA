using ExportData.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExportData.UI.Services
{
    internal class LinqCreateService
    {
        public static List<Person> EnterQuery(List<Person> persons, string field, string value)
        {
            switch (field)
            {
                case "Дата":
                    var result = from person in persons
                                 where person.Date == Convert.ToDateTime(value)
                                 select person;
                    return result.ToList();
                    break;
                case "Имя":
                    result = from person in persons
                             where person.FirstName == value
                             select person;
                    return result.ToList();
                    break;
                case "Фамилия":
                    result = from person in persons
                             where person.LastName == value
                             select person;
                    return result.ToList();
                    break;
                case "Отчество":
                    result = from person in persons
                             where person.SurName == value
                             select person;
                    return result.ToList();
                    break;
                case "Город":
                    result = from person in persons
                             where person.City == value
                             select person;
                    return result.ToList();
                    break;
                case "Страна":
                    result = from person in persons
                             where person.Country == value
                             select person;
                    return result.ToList();
                    break;
                default:
                    return null;
                    break;
            }

        }
    }
}
