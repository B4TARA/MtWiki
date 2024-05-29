using Microsoft.EntityFrameworkCore;
using MtWiki.DAL.Entities;

namespace MtWiki.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rkc> Rkcs { get; set; }
        public DbSet<LeadershipPosition> LeadershipPositions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeadershipPosition>(builder =>
            {
                builder.HasData(new LeadershipPosition[]
                {
                    new LeadershipPosition
                    {
                        Id = 1,
                        LeadershipPositionName = "Председатель правления",
                    },
                    new LeadershipPosition
                    {
                        Id = 2,
                        LeadershipPositionName = "Заместитель председателя правления",
                    },
                    new LeadershipPosition
                    {
                        Id = 3,
                        LeadershipPositionName = "Директор по розничному бизнесу",
                    },
                    new LeadershipPosition
                    {
                        Id = 4,
                        LeadershipPositionName = "Финансовый директор",
                    },
                    new LeadershipPosition
                    {
                        Id = 5,
                        LeadershipPositionName = "Директор по управлению персоналом",
                    },
                    new LeadershipPosition
                    {
                        Id = 6,
                        LeadershipPositionName = "Директор по цифровому развитию",
                    },
                    new LeadershipPosition
                    {
                        Id = 7,
                        LeadershipPositionName = "Директор по информационным технологиям",
                    },
                    new LeadershipPosition
                    {
                        Id = 8,
                        LeadershipPositionName = "Директор по методологии клиентских операций и кредитованию",
                    },
                    new LeadershipPosition
                    {
                        Id = 9,
                        LeadershipPositionName = "Директор по крупному бизнесу",
                    },
                    new LeadershipPosition
                    {
                        Id = 10,
                        LeadershipPositionName = "Директор по малому и среднему бизнесу",
                    },
                    new LeadershipPosition
                    {
                        Id = 11,
                        LeadershipPositionName = "Директор по продажам",
                    },
                    new LeadershipPosition
                    {
                        Id = 12,
                        LeadershipPositionName = "Инженер по охране труда",
                    },
                    new LeadershipPosition
                    {
                        Id = 13,
                        LeadershipPositionName = "Исполнительный директор",
                    },
                    new LeadershipPosition
                    {
                        Id = 14,
                        LeadershipPositionName = "Главный бухгалтер",
                    },
                    new LeadershipPosition
                    {
                        Id = 15,
                        LeadershipPositionName = "Директор по правовому обеспечению",
                    },
                });              
            });

            modelBuilder.Entity<Rkc>(builder =>
            {
                builder.HasData(new Rkc[]
                {
                    new Rkc
                    {
                        Id = 1,
                        RkcName = "ExampleName",
                        DepartmentId = 1,
                    },
                });
            });

            modelBuilder.Entity<Department>(builder =>
            {
                builder.HasData(new Department[]
                {
                    new Department
                    {
                        Id = 1,
                        DepartmentName = "УБ  Управление безопасности",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 2,
                        DepartmentName = "МАР Управление маркетинга",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 3,
                        DepartmentName = "УВК Управление внутреннего контроля",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 4,
                        DepartmentName = "УВА Управления внутреннего аудита",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 5,
                        DepartmentName = "УРМ Управление риск-менеджмента",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 6,
                        DepartmentName = "Управление информационной безопасности",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 7,
                        DepartmentName = "УД Управление делами",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 8,
                        DepartmentName = "Центр управления бизнес-процессами",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 9,
                        DepartmentName = "УКС Управление клиентского сервиса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 10,
                        DepartmentName = "УСАОКСБ Управление сопровождения активных операций крупного и среднего бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 11,
                        DepartmentName = "УПС Управление поддержки сети",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 12,
                        DepartmentName = "УРКБ Управление развития корпоративного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 13,
                        DepartmentName = "УРРП Управление развития розничных продуктов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 14,
                        DepartmentName = "КАЗ Казначейство",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 15,
                        DepartmentName = "УБУ Управление бухгалтерского учета",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 16,
                        DepartmentName = "ФЭУ Финансово-экономическое управление",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 17,
                        DepartmentName = "УМО Управление межбанковских отношений",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 18,
                        DepartmentName = "ЮР  Юридическое управление",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 19,
                        DepartmentName = "УОСКУ Управление организации системы корпоративного управления",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 20,
                        DepartmentName = "ОВКОПД Отдел по внутреннему контролю за обработкой персональных данных",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 21,
                        DepartmentName = "УРП Управление по работе с персоналом",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 22,
                        DepartmentName = "УОП Управление обучения персонала",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 23,
                        DepartmentName = "УМСТ Управление мотивации и стимулирования труда",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 24,
                        DepartmentName = "ЦУП Центр управления проектами",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 25,
                        DepartmentName = "УЦРКБ Управление цифрового развития корпоративного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 26,
                        DepartmentName = "УЦРРБ Управление цифрового развития розничного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 27,
                        DepartmentName = "УБПК Управление банковских платежных карточек",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 28,
                        DepartmentName = "ЦАР Центр аналитических решений",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 29,
                        DepartmentName = "УЭИС Управление эксплуатации информационных систем",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 30,
                        DepartmentName = "УРИС Управление развития информационных систем",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 31,
                        DepartmentName = "УТППМ Управление технической поддержки пользователей и мониторинга",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 32,
                        DepartmentName = "ОУПДРИТ Отдел управления процессами договорной работы ИТ",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 33,
                        DepartmentName = "УРПА Управление по работе с проблемными активами",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 34,
                        DepartmentName = "УЭКПФЛ Управление экспертизы кредитных проектов физических лиц",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 35,
                        DepartmentName = "УКР Управление кредитных рисков",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 36,
                        DepartmentName = "УМКО Управление методологии клиентских операций",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 37,
                        DepartmentName = "УСЗК Управление сопровождения значимых клиентов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 38,
                        DepartmentName = "УРОЗК Управление развития отношений со значимыми клиентами",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 39,
                        DepartmentName = "УЭКПСКБ Управление экспертизы кредитных проектов среднего и крупного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 40,
                        DepartmentName = "УКММБ Управление кредитования малого и микробизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 41,
                        DepartmentName = "УКБ Управление клиентского бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 42,
                        DepartmentName = "Подразделения корпоративной сети Банка",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 43,
                        DepartmentName = "ЦЛ Центр лизинга",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 44,
                        DepartmentName = "УРКО Управление по расчетно-кассовому обслуживанию корпоративных клиентов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 45,
                        DepartmentName = "УОРО Управление обслуживания розничных операций",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 46,
                        DepartmentName = "УМР Управление международных расчетов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 47,
                        DepartmentName = "УКО Управление кассовых операций",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 48,
                        DepartmentName = "УРПСП Управление розничных продаж в сети партнеров",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 49,
                        DepartmentName = "УМиЛ Управление методологии и лидогенерации",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 50,
                        DepartmentName = "УПРБ Управление продаж розничного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 51,
                        DepartmentName = "УКОп Управление клиентского опыта",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 52,
                        DepartmentName = "УРРПП Управление развития розничных продуктов и процессов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 53,
                        DepartmentName = "УПО Управление премиального обслуживания",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 54,
                        DepartmentName = "УИБ Управление инвестиционного бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 55,
                        DepartmentName = "ОД Операционный департамент",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 56,
                        DepartmentName = "УРВИРК Управление развития и внедрения инноваций для розничных клиентов",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 57,
                        DepartmentName = "УМиЛ Управление методологии и лидогенерации малого и среднего бизнеса",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 58,
                        DepartmentName = "УКПР Управление корпоративных продаж",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 59,
                        DepartmentName = "УИТ Управление информационных технологий",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 60,
                        DepartmentName = "УДПО Управление дистанционных продаж и обслуживания",
                        DepartmentDescription = "",
                    },
                    new Department
                    {
                        Id = 61,
                        DepartmentName = "Отдел развития автоматизации и аналитики систем управления персоналом",
                        DepartmentDescription = "",
                    },
                });
            });
        }
    }
}
