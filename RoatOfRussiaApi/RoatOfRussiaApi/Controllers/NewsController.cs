using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;

namespace RoatOfRussiaApi.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news")]
        public IHttpActionResult Get()
        {
            
            var xmlString = "<rss version=\"2.0\">\r\n<channel>\r\n<title>Новости Дороги России</title>\r\n<link>https://pro.firpo.ru/</link>\r\n<description>Новости Дороги России</description>\r\n<item>\r\n<guid isPermaLink=\"false\">7fd8697e-8b7d-4665-9a9e-22a0b9aa4ee8</guid>\r\n<link>https://rosavtodor.gov.ru/press-center/news?page=2</link>\r\n<title>Почти 700 км федеральных трасс реконструируют и построят по нацпроекту</title>\r\n<description>В 2024 году благодаря реализации федерального проекта «Развитие федеральной магистральной сети» нацпроекта «Безопасные качественные дороги» в России будет построено и реконструировано 693,4 км автомобильных дорог федерального значения. Строительно-монтажные работы выполняются на участках дорог Росавтодора (бесплатные трассы) и на тех, которые находятся в доверительном управлении ГК «Автодор» (платные).</description>\r\n<image>https://images.wallpaperscraft.com/image/single/lake_mountain_tree_36589_2650x1600.jpg</image>\r\n</item>\r\n<item>\r\n<guid isPermaLink=\"false\">5dadfdaf-63c6-4f4d-b266-ae02f1f75c48</guid>\r\n<link>https://rosavtodor.gov.ru/press-center/news?page=2</link>\r\n<title>Цифровизация и технологическое лидерство как основа развития дорожно-транспортного комплекса РФ</title>\r\n<description>15 мая на Международной выставке-форуме «Россия» в Москве в рамках Недели технологического лидерства прошел тематический день «Транспортная мобильность». Ключевым мероприятием в деловой программе стала пленарная сессия «Технологическое лидерство: транспортная мобильность. Перспективы цифровизации транспортного комплекса и развития беспилотных технологий». </description>\r\n<image>https://192.168.1.85:5000/images/4.jpg</image>\r\n</item>\r\n<item>\r\n<guid isPermaLink=\"false\">5fa138b1-2094-4336-b7d3-d05861524142</guid>\r\n<link>https://rosavtodor.gov.ru/press-center/news?page=2</link>\r\n<title>Дорожники приступили к работам на объектах нацпроекта</title>\r\n<description>Во многих регионах страны стартовали работы по национальному проекту «Безопасные качественные дороги». В этом году к нормативу приведут 5,2 тыс. объектов общей протяженностью 14,6 тыс. км.</description>\r\n<image>https://get.wallhere.com/photo/trees-water-clouds-lightning-nature-forest-Slovenia-1154285.jpg</image>\r\n</item>\r\n<item>\r\n<guid isPermaLink=\"false\">dfde5fb6-a692-45eb-8ff2-3ef0c1143554</guid>\r\n<link>https://rosavtodor.gov.ru/press-center/news?page=2</link>\r\n<title>Росавтодор: ключевая цель – обеспечить безопасное и бесперебойное движение транспорта по федеральным трассам УрФО и ПФО в период паводков</title>\r\n<description>В связи со сложной паводковой ситуацией в ряде субъектов УрФО и ПФО – Оренбургской, Челябинской, Курганской и Тюменской областях – федеральные дорожники перешли в режим повышенной готовности. Созданы оперативные штабы, ведется регулярный мониторинг дорожной ситуации на подведомственной Росавтодору сети, особое внимание уделяется наиболее паводкоопасным участкам. В настоящий момент движение транспорта по федеральным трассам указанных регионов осуществляется в штатном режиме.</description>\r\n<image>https://192.168.1.85:5000/images/7.jpg</image>\r\n</item>\r\n<item>\r\n<guid isPermaLink=\"false\">d3750347-dc98-493b-bbd4-6a7d1920be27</guid>\r\n<link>https://rosavtodor.gov.ru/press-center/news?page=2</link>\r\n<title>Протяженность опорной сети автомобильных дорог увеличилась почти до 140,5 тыс. км</title>\r\n<description>Протяженность автомобильных дорог опорной сети Российской Федерации составляет 140,5 тыс. км*. Об этом 5 апреля сообщил руководитель Федерального дорожного агентства Роман Новиков в ходе совещания, посвященного выполнению программы дорожных работ в I квартале 2024 года. С 21 февраля по 13 марта этого года в Росавтодоре состоялась серия очных совещаний с региональными проектными командами, в ходе которых актуализированы детали пятилетних программ субъектов РФ. По результатам этих мероприятий с 88 регионами страны будут подписаны дополнительные соглашения к меморандумам о развитии автодорог общего пользования регионального или межмуниципального и местного значения. В результате этой работы протяженность автомобильных дорог регионального или межмуниципального значения, входящих в опорную сеть, составила 74,3 тыс. км.</description>\r\n</item>\r\n</channel>\r\n</rss>";
            var content = new StringContent(xmlString, Encoding.UTF8, "application/rss+xml");
            return ResponseMessage(new HttpResponseMessage
            {
                Content = content,
                StatusCode = HttpStatusCode.OK,
            });
        }
    }
}
