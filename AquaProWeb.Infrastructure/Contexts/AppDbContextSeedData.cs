using AquaProWeb.Common.Enums;
using AquaProWeb.Domain.Entities;
using Newtonsoft.Json;

namespace AquaProWeb.Infrastructure.Contexts
{


    public class AppDbContextSeedData
    {
        public static async Task LoadDataAsync(AppDbContext context)
        {
            try
            {



                // Explotacio
                if (!context.Explotacions!.Any())
                {
                    var explotacioData = new Explotacio
                    {
                        Codi = "01",
                        Nom = "Explotacio1",
                        Observacions = "Primera explotació"
                    };
                    await context.AddAsync(explotacioData);
                    await context.SaveChangesAsync();
                }
                //Paisos
                if (!context.Paisos!.Any())
                {
                    var paisData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\countries.json");
                    var paisos = JsonConvert.DeserializeObject<List<Pais>>(paisData);
                    await context.Paisos!.AddRangeAsync(paisos!);
                    await context.SaveChangesAsync();
                }
                //Avisos
                if (!context.Avisos!.Any())
                {
                    var avisData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Avisos.json");
                    var avisos = JsonConvert.DeserializeObject<List<Avis>>(avisData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });

                    await context.Avisos!.AddRangeAsync(avisos!);
                    await context.SaveChangesAsync();
                }
                //Operaris
                if (!context.Operaris!.Any())
                {
                    var operariData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Operaris.json");
                    var operari = JsonConvert.DeserializeObject<List<Operari>>(operariData);
                    await context.Operaris!.AddRangeAsync(operari!);
                    await context.SaveChangesAsync();
                }

                //Poblacions
                if (!context.Poblacions!.Any())
                {
                    var poblacioData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Poblacions.json");
                    var poblacions = JsonConvert.DeserializeObject<List<Poblacio>>(poblacioData);

                    await context.Poblacions!.AddRangeAsync(poblacions!);
                    await context.SaveChangesAsync();
                }

                // Tipus Via
                if (!context.TipusVies!.Any())
                {
                    var tipusViaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\TipusVia.json");
                    var tipusVia = JsonConvert.DeserializeObject<List<TipusVia>>(tipusViaData);
                    await context.TipusVies!.AddRangeAsync(tipusVia!);
                    await context.SaveChangesAsync();
                }

                //Zona Carrers
                if (!context.ZonesCarrers!.Any())
                {
                    var zonaCarrersData = new List<ZonaCarrers>()
                    {
                        new ZonaCarrers() { Zona = "Zona1", Descripcio = "Zona Nord", Observacions = "" },
                        new ZonaCarrers() { Zona = "Zona2", Descripcio = "Zona Sud", Observacions = "" },
                        new ZonaCarrers() { Zona = "Zona3", Descripcio = "Zona Est", Observacions = "" },
                        new ZonaCarrers() { Zona = "Zona4", Descripcio = "Zona Oest", Observacions = "" },
                    };

                    await context.ZonesCarrers.AddRangeAsync(zonaCarrersData);
                    await context.SaveChangesAsync();
                }

                //Carrers
                if (!context.Carrers!.Any())
                {
                    var carrerData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Carrers.json");
                    var carrer = JsonConvert.DeserializeObject<List<Carrer>>(carrerData);
                    await context.Carrers!.AddRangeAsync(carrer!);
                    await context.SaveChangesAsync();
                }

                // Motius Baixa Contactes
                if (!context.MotiusBaixaContacte!.Any())
                {
                    var motiusBaixaContactesData = new List<MotiuBaixaContacte>()
                    {
                        new MotiuBaixaContacte() { Motiu = "Voluntaria", Observacions = "" },
                        new MotiuBaixaContacte() { Motiu = "Defunció", Observacions = "" },
                        new MotiuBaixaContacte() { Motiu = "Tecnica", Observacions = "" },
                        new MotiuBaixaContacte() { Motiu = "Baixa Contracte", Observacions = "" },
                    };
                    await context.MotiusBaixaContacte!.AddRangeAsync(motiusBaixaContactesData!);
                    await context.SaveChangesAsync();
                }

                // Families Contracte
                if (!context.FamiliesContracte!.Any())
                {
                    var familiaData = new List<FamiliaContracte>()
                    {
                        new FamiliaContracte
                        {
                            Codi = "PAR", Familia = "Particulars", Descripcio = "Particulars",
                            Observacions = "aaaaaaaaaaaaa bbbbbbb  csdsdc dsdds ddfdf d dddddd"
                        },
                        new FamiliaContracte
                        {
                            Codi = "EMP", Familia = "Empreses", Descripcio = "Empreses",
                            Observacions = "gfggfjhjhj trtrtr"
                        },
                        new FamiliaContracte
                        {
                            Codi = "ESC", Familia = "Escoles", Descripcio = "Escoles",
                            Observacions = "fddff ffdf  dfffddff fgg g"
                        },
                        new FamiliaContracte
                        {
                            Codi = "ADM", Familia = "Administracions", Descripcio = "Administracions",
                            Observacions = "gfgffgf fgfgfgfg gytrt  ttrt trt tttrtfdfd "
                        },
                        new FamiliaContracte
                        {
                            Codi = "RAM", Familia = "Ramaderia", Descripcio = "Ramaderia",
                            Observacions = "dfdfeer fggh rtrtrb fgfg "
                        }
                    };
                    await context.AddRangeAsync(familiaData);
                    await context.SaveChangesAsync();
                }

                // Usos Contracte
                if (!context.UsosContracte!.Any())
                {
                    var usContracteData = new List<UsContracte>()
                    {
                        new UsContracte() { Codi = "DOM", Us = "Domestic", Descripcio = "", Observacions = "" },
                        new UsContracte() { Codi = "IND", Us = "Industrial", Descripcio = "", Observacions = "" },
                        new UsContracte() { Codi = "RAM", Us = "Ramader", Descripcio = "", Observacions = "" },
                        new UsContracte() { Codi = "COM", Us = "Comercial", Descripcio = "", Observacions = "" },

                    };

                    await context.UsosContracte.AddRangeAsync(usContracteData);
                    await context.SaveChangesAsync();
                }

                // Ramals
                if (!context.Ramals!.Any())
                {
                    var ramals = new List<Ramal>()
                    {
                        new Ramal { Nom = "Ramal1", Descripcio = "Ramal de la zona 1", Observacions = "ramalllllllll" },
                        new Ramal { Nom = "Ramal2", Descripcio = "Ramal de la zona 2", Observacions = "raaaaaaaamal" },
                        new Ramal
                        {
                            Nom = "Ramal3", Descripcio = "Ramal de la zona 3", Observacions = "rammmmaaaaalll"
                        },
                        new Ramal { Nom = "Ramal4", Descripcio = "Ramal de la zona 4", Observacions = "ramalaaaaaaaa" },
                        new Ramal
                        {
                            Nom = "Ramal5", Descripcio = "Ramal de la zona 5", Observacions = "rrrramallllllll"
                        },

                    };

                    await context.AddRangeAsync(ramals);
                    await context.SaveChangesAsync();
                }

                // Escomeses
                if (!context.Escomeses!.Any())
                {
                    var escomesesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Escomeses.json");
                    var escomeses = JsonConvert.DeserializeObject<List<Escomesa>>(escomesesData);
                    await context.Escomeses!.AddRangeAsync(escomeses!);
                    await context.SaveChangesAsync();
                }

                // Components escomesa
                if (!context.Components!.Any())
                {
                    var componentsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Components.json");
                    var components = JsonConvert.DeserializeObject<List<Component>>(componentsData);
                    await context.Components!.AddRangeAsync(components!);
                    await context.SaveChangesAsync();
                }

                // Tipus Ubicacio
                if (!context.TipusUbicacions!.Any())
                {
                    var tipusUbicacioData = new List<TipusUbicacio>()
                    {
                        new TipusUbicacio()
                            { Tipus = "Comptador", Descripcio = "Ubicació amb comptador", Observacions = "" },
                        new TipusUbicacio()
                            { Tipus = "Servei", Descripcio = "Ubicació sense comptador", Observacions = "" },
                        new TipusUbicacio()
                            { Tipus = "Aforament", Descripcio = "Ubicació amb aforament", Observacions = "" },
                    };

                    await context.TipusUbicacions.AddRangeAsync(tipusUbicacioData);
                    await context.SaveChangesAsync();
                }

                // Zones Ubicacions
                if (!context.ZonesUbicacions!.Any())
                {
                    var zonaUbicacioData = new List<ZonaUbicacio>()
                    {
                        new ZonaUbicacio() { Zona = "Centre", Descripcio = "Zona Ciutat", Observacions = "" },
                        new ZonaUbicacio() { Zona = "Poligon", Descripcio = "Poligon Industrial", Observacions = "" },
                        new ZonaUbicacio()
                            { Zona = "Urb1", Descripcio = "Urbanització de Can salva", Observacions = "" },
                        new ZonaUbicacio()
                            { Zona = "Urb2", Descripcio = "Urbanització de la Plana", Observacions = "" },
                        new ZonaUbicacio()
                            { Zona = "Urb3", Descripcio = "Urbanització de L'Espelt", Observacions = "" },
                        new ZonaUbicacio() { Zona = "Dis", Descripcio = "Masies Diseminades", Observacions = "" },
                    };

                    await context.ZonesUbicacions.AddRangeAsync(zonaUbicacioData);
                    await context.SaveChangesAsync();
                }

                // Rutes lectura
                if (!context.RutesLectura!.Any())
                {
                    var rutes = new List<RutaLectura>()
                    {
                        new RutaLectura (){ Ruta="Ruta1", Descripcio = "Ruta de lectura 1", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta2", Descripcio = "Ruta de lectura 2", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta3", Descripcio = "Ruta de lectura 3", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta4", Descripcio = "Ruta de lectura 4", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta5", Descripcio = "Ruta de lectura 5", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta6", Descripcio = "Ruta de lectura 6", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta7", Descripcio = "Ruta de lectura 7", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta8", Descripcio = "Ruta de lectura 8", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta9", Descripcio = "Ruta de lectura 9", Observacions = ""},
                        new RutaLectura (){ Ruta="Ruta10", Descripcio = "Ruta de lectura 10", Observacions = ""},
                    };

                    await context.AddRangeAsync(rutes);
                    await context.SaveChangesAsync();
                }

                // Ubicacio
                if (!context.Ubicacions!.Any())
                {
                    var ubicacionsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Ubicacions.json");
                    var ubicacions = JsonConvert.DeserializeObject<List<Ubicacio>>(ubicacionsData,
                        new JsonSerializerSettings
                        {
                            DateFormatString = "dd/MM/yyyy"
                        });
                    await context.Ubicacions!.AddRangeAsync(ubicacions!);
                    await context.SaveChangesAsync();
                }

                // Zones facturacio
                if (!context.ZonesFacturacio!.Any())
                {
                    var zonaFacturacioData = new List<ZonaFacturacio>()
                    {
                        new ZonaFacturacio(){Zona = "ZonaA", Descripcio="Zona Facturacio A", Observacions=""},
                        new ZonaFacturacio(){Zona = "ZonaB", Descripcio="Zona Facturacio B", Observacions=""},
                        new ZonaFacturacio(){Zona = "ZonaC", Descripcio="Zona Facturacio C", Observacions=""},
                        new ZonaFacturacio(){Zona = "ZonaD", Descripcio="Zona Facturacio D", Observacions=""},
                    };

                    await context.ZonesFacturacio.AddRangeAsync(zonaFacturacioData);
                    await context.SaveChangesAsync();
                }

                // Contractes
                if (!context.Contractes!.Any())
                {
                    var contractesData =
                        File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Contractes.json");
                    var contractes = JsonConvert.DeserializeObject<List<Contracte>>(contractesData,
                        new JsonSerializerSettings
                        {
                            DateFormatString = "dd/MM/yyyy"
                        });
                    await context.Contractes!.AddRangeAsync(contractes!);
                    await context.SaveChangesAsync();
                }

                // anotacions contracte
                if (!context.AnotacionsContractes!.Any())
                {
                    var anotacioContracteData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\AnotacionsContracte.json");
                    var anotacionsContracte = JsonConvert.DeserializeObject<List<AnotacioContracte>>(anotacioContracteData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.AnotacionsContractes!.AddRangeAsync(anotacionsContracte!);
                    await context.SaveChangesAsync();
                }

                // Series Factura
                if (!context.SeriesFactura!.Any())
                {
                    var series = new List<SerieFactura>()
                    {
                        new SerieFactura
                        {
                            Serie = "Serie1", Comptador = 1, Prefix = "", Postfix = "",
                            Descripcio = "Serie Factures Primera", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Serie2", Comptador = 1, Prefix = "", Postfix = "",
                            Descripcio = "Serie Factures Segona", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Serie3", Comptador = 1, Prefix = "", Postfix = "",
                            Descripcio = "Serie Factures Tercera", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Serie4", Comptador = 1, Prefix = "", Postfix = "",
                            Descripcio = "Serie Factures Quarta", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Serie5", Comptador = 1, Prefix = "", Postfix = "",
                            Descripcio = "Serie Factures Cinquena", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Abonaments", Comptador = 1, Prefix = "ABO", Postfix = "",
                            Descripcio = "Serie Factures Abonaments", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Rectificacions", Comptador = 1, Prefix = "ESM", Postfix = "",
                            Descripcio = "Serie Factures Esmenes", Observacions = ""
                        },
                        new SerieFactura
                        {
                            Serie = "Fiances", Comptador = 1, Prefix = "FIA", Postfix = "",
                            Descripcio = "Serie Factures Fiances", Observacions = ""
                        },
                    };
                    await context.AddRangeAsync(series);
                    await context.SaveChangesAsync();
                }

                // Series Rebuts
                if (!context.SeriesRebut!.Any())
                {
                    var series = new List<SerieRebut>()
                    {
                        new SerieRebut
                        {
                            Serie = "Normal", Comptador = 1, Prefix = "", Postfix = "", Descripcio = "Serie Rebuts",
                            Observacions = ""
                        },
                        new SerieRebut
                        {
                            Serie = "Abonaments", Comptador = 1, Prefix = "ABO", Postfix = "",
                            Descripcio = "Serie Abonaments", Observacions = ""
                        },
                        new SerieRebut
                        {
                            Serie = "Rectificacions", Comptador = 1, Prefix = "ESM", Postfix = "",
                            Descripcio = "Serie Esmenes", Observacions = ""
                        },
                    };
                    await context.AddRangeAsync(series);
                    await context.SaveChangesAsync();
                }

                //Conceptes Cobrament
                if (!context.ConceptesCobrament!.Any())
                {
                    var concepteCobramentData = new List<ConcepteCobrament>()
                    {
                        new ConcepteCobrament
                        {
                            Concepte = "Caixa", Descripcio = "Cobrament Caixa", Observacions = "", CodiComptable = ""
                        },
                        new ConcepteCobrament
                        {
                            Concepte = "Transferencia", Descripcio = "Cobrament Transferencia", Observacions = "",
                            CodiComptable = ""
                        },
                        new ConcepteCobrament
                            { Concepte = "TPV", Descripcio = "Cobrament TPV", Observacions = "", CodiComptable = "" },
                        new ConcepteCobrament
                        {
                            Concepte = "Remesa", Descripcio = "Cobrament Remesa", Observacions = "", CodiComptable = ""
                        },
                        new ConcepteCobrament
                        {
                            Concepte = "Finestreta", Descripcio = "Cobrament finestreta", Observacions = "",
                            CodiComptable = ""
                        }
                    };
                    await context.AddRangeAsync(concepteCobramentData);
                    await context.SaveChangesAsync();
                }

                // Situacions factura
                if (!context.SituacionsFactura!.Any())
                {
                    var situacionsFra = new List<SituacioFactura>()
                    {
                        new SituacioFactura()
                            { Estat = EstatFactura.Pendent, Situacio = "Emesa", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                            { Estat = EstatFactura.Pendent, Situacio = "Parcial", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                            { Estat = EstatFactura.Pendent, Situacio = "Impagada", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                            { Estat = EstatFactura.Cobrada, Situacio = "Caixa", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                        {
                            Estat = EstatFactura.Cobrada, Situacio = "Transferencia", Descripcio = "", Observacions = ""
                        },
                        new SituacioFactura()
                            { Estat = EstatFactura.Cobrada, Situacio = "TPV", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                            { Estat = EstatFactura.Cobrada, Situacio = "Remesa", Descripcio = "", Observacions = "" },
                        new SituacioFactura()
                        {
                            Estat = EstatFactura.Executiva, Situacio = "Executiva", Descripcio = "", Observacions = ""
                        },
                        new SituacioFactura()
                            { Estat = EstatFactura.Anulada, Situacio = "Anulada", Descripcio = "", Observacions = "" },
                    };

                    await context.SituacionsFactura.AddRangeAsync(situacionsFra);
                    await context.SaveChangesAsync();
                }

                // Situacions Rebut
                if (!context.SituacionsRebut!.Any())
                {
                    var situacionsRebut = new List<SituacioRebut>()
                    {
                        new SituacioRebut()
                            { Estat = EstatRebut.Pendent, Situacio = "Emes", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                            { Estat = EstatRebut.Pendent, Situacio = "Parcial", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                            { Estat = EstatRebut.Pendent, Situacio = "Impagat", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                            { Estat = EstatRebut.Cobrat, Situacio = "Caixa", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                        {
                            Estat = EstatRebut.Cobrat, Situacio = "Transferencia", Descripcio = "", Observacions = ""
                        },
                        new SituacioRebut()
                            { Estat = EstatRebut.Cobrat, Situacio = "Remesa", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                            { Estat = EstatRebut.Cobrat, Situacio = "Finestreta", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                            { Estat = EstatRebut.Cobrat, Situacio = "TPV", Descripcio = "", Observacions = "" },
                        new SituacioRebut()
                        {
                            Estat = EstatRebut.Executiva, Situacio = "Executiva", Descripcio = "", Observacions = ""
                        },
                        new SituacioRebut()
                            { Estat = EstatRebut.Anulat, Situacio = "Anulat", Descripcio = "", Observacions = "" },
                    };
                    await context.SituacionsRebut.AddRangeAsync(situacionsRebut);
                    await context.SaveChangesAsync();
                }

                // Tipus OT
                if (!context.TipusOrdresTreball!.Any())
                {
                    var tipusQueixaData = new List<TipusOrdreTreball>()
                    {
                        new TipusOrdreTreball()
                            { Tipus = "Revisio", Descripcio = "Revisar incidencia", Observacions = "" },
                        new TipusOrdreTreball()
                            { Tipus = "Reparacio", Descripcio = "Reparar averia", Observacions = "" },
                        new TipusOrdreTreball()
                            { Tipus = "Obres", Descripcio = "Obres en la escomesa", Observacions = "" },
                        new TipusOrdreTreball()
                            { Tipus = "Alta", Descripcio = "Alta escomesa", Observacions = "" },
                        new TipusOrdreTreball()
                            { Tipus = "Baixa", Descripcio = "Baixa escomesa", Observacions = "" },
                        new TipusOrdreTreball()
                            { Tipus = "Canvi Comptador", Descripcio = "Canvi de comptador", Observacions = "" },
                    };

                    await context.TipusOrdresTreball.AddRangeAsync(tipusQueixaData);
                    await context.SaveChangesAsync();
                }

                // Tipus Client
                if (!context.TipusClients!.Any())
                {
                    var tipusClientData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\TipusClient.json");
                    var tipusClient = JsonConvert.DeserializeObject<List<TipusClient>>(tipusClientData);
                    await context.TipusClients!.AddRangeAsync(tipusClient!);
                    await context.SaveChangesAsync();
                }

                //Clients
                if (!context.Clients!.Any())
                {
                    var clientData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Clients.json");
                    var clients = JsonConvert.DeserializeObject<List<Client>>(clientData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.Clients!.AddRangeAsync(clients!);
                    await context.SaveChangesAsync();
                }
                // Rebuts

                if (!context.Rebuts!.Any())
                {
                    var rebutsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Rebuts.json");
                    var rebuts = JsonConvert.DeserializeObject<List<Rebut>>(rebutsData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.Rebuts!.AddRangeAsync(rebuts!);
                    await context.SaveChangesAsync();
                }

                // anotacio rebuts
                if (!context.AnotacionsRebuts!.Any())
                {
                    var anotacioRebutData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\AnotacionsRebut.json");
                    var anotacionsRebut = JsonConvert.DeserializeObject<List<AnotacioRebut>>(anotacioRebutData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.AnotacionsRebuts!.AddRangeAsync(anotacionsRebut!);
                    await context.SaveChangesAsync();
                }

                // Tipus Factura
                if (!context.TipusFactures!.Any())
                {
                    var tipusFacturaData = new List<TipusFactura>()
                    {
                        new TipusFactura() { Tipus = "FIANÇA", Descripcio = "Factura de fiança", Observacions = "" },
                        new TipusFactura() { Tipus = "OBRA", Descripcio = "Factura d'obres varies", Observacions = "" },
                        new TipusFactura()
                            { Tipus = "DESPESES", Descripcio = "Factura de despeses varies", Observacions = "" },
                        new TipusFactura()
                            { Tipus = "ALTA", Descripcio = "Factura alta subministrament", Observacions = "" },
                        new TipusFactura() { Tipus = "BAIXA", Descripcio = "Factura de baixa", Observacions = "" },
                        new TipusFactura()
                            { Tipus = "REPARACIO", Descripcio = "Factura reparació instal.lació", Observacions = "" },
                    };

                    await context.TipusFactures.AddRangeAsync(tipusFacturaData);
                    await context.SaveChangesAsync();
                }

                // Factures
                if (!context.Factures.Any())
                {
                    var facturesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Factures.json");
                    var factures = JsonConvert.DeserializeObject<List<Factura>>(facturesData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.Factures!.AddRangeAsync(factures!);
                    await context.SaveChangesAsync();
                }

                //anotacions factura
                if (!context.AnotacionsFactures!.Any())
                {
                    var anotacioFacturaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\AnotacionsFactura.json");
                    var anotacionsFactura = JsonConvert.DeserializeObject<List<AnotacioFactura>>(anotacioFacturaData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.AnotacionsFactures!.AddRangeAsync(anotacionsFactura!);
                    await context.SaveChangesAsync();
                }

                // Zones OT
                if (!context.ZonesOrdresTreball!.Any())
                {
                    var zonaOTData = new List<ZonaOrdreTreball>()
                    {
                        new ZonaOrdreTreball()
                            { Zona = "ZonaOT1", Descripcio = "Zona Equip Treball 1", Observacions = "" },
                        new ZonaOrdreTreball()
                            { Zona = "ZonaOT2", Descripcio = "Zona Equip Treball 2", Observacions = "" },
                        new ZonaOrdreTreball()
                            { Zona = "ZonaOT3", Descripcio = "Zona Equip Treball 3", Observacions = "" },
                        new ZonaOrdreTreball()
                            { Zona = "ZonaOT4", Descripcio = "Zona Equip Treball 4", Observacions = "" },
                        new ZonaOrdreTreball()
                            { Zona = "ZonaOT5", Descripcio = "Zona Equip Treball 5", Observacions = "" },
                    };

                    await context.ZonesOrdresTreball.AddRangeAsync(zonaOTData);
                    await context.SaveChangesAsync();
                }

                // situacions administratives OT

                if (!context.SituacionsAdministrativesOT!.Any())
                {
                    var situacionsAdminOT = new List<SituacioAdministrativaOT>()
                    {
                        new SituacioAdministrativaOT()
                            { Situacio = "SituacioAdminOT1", Descripcio = "Situacio Administrativa OT 1", Observacions = "" },
                        new SituacioAdministrativaOT()
                            { Situacio = "SituacioAdminOT2", Descripcio = "Situacio Administrativa OT 2", Observacions = "" },
                        new SituacioAdministrativaOT()
                            { Situacio = "SituacioAdminOT3", Descripcio = "Situacio Administrativa OT 3", Observacions = "" },
                        new SituacioAdministrativaOT()
                            { Situacio = "SituacioAdminOT4", Descripcio = "Situacio Administrativa OT 4", Observacions = "" },
                        new SituacioAdministrativaOT()
                            { Situacio = "SituacioAdminOT5", Descripcio = "Situacio Administrativa OT 5", Observacions = "" },
                    };

                    await context.SituacionsAdministrativesOT.AddRangeAsync(situacionsAdminOT);
                    await context.SaveChangesAsync();
                }

                // Ordres Treball
                if (!context.OrdresTreball.Any())
                {
                    var otData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\OrdresTreball.json");
                    var ots = JsonConvert.DeserializeObject<List<OrdreTreball>>(otData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.OrdresTreball!.AddRangeAsync(ots!);
                    await context.SaveChangesAsync();
                }

                // anotacions OT
                if (!context.AnotacionsOrdresTreball!.Any())
                {
                    var anotacioOTData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\AnotacionsOrdreTreball.json");
                    var anotacionsOT = JsonConvert.DeserializeObject<List<AnotacioOrdreTreball>>(anotacioOTData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.AnotacionsOrdresTreball!.AddRangeAsync(anotacionsOT!);
                    await context.SaveChangesAsync();
                }

                // Tipus campanya
                if (!context.TipusCampanyes!.Any())
                {
                    var tipusCampanyaData = new List<TipusCampanya>()
                    {
                        new TipusCampanya(){ Tipus = "Avis", Descripcio= "Campanya avisos", Observacions=""},
                        new TipusCampanya(){ Tipus = "Tall", Descripcio="Campanya de tall", Observacions=""},
                        new TipusCampanya(){ Tipus = "Deute", Descripcio="Campanya avis deute", Observacions=""},
                        new TipusCampanya(){ Tipus = "Informacio", Descripcio="Campanya informativa", Observacions=""}
                    };

                    await context.TipusCampanyes.AddRangeAsync(tipusCampanyaData);
                    await context.SaveChangesAsync();
                }

                //Campanyes

                if (!context.Campanyes!.Any())
                {
                    var campanyaData = new List<Campanya>()
                    {
                        new Campanya { Nom = "Campanya Avis Tall", TipusCampanyaId = 1, DataCampanya = new DateTime(2022, 1, 1), Descripcio = "Campanya de avis de tall de subministrament barri del Pi", Observacions = "" },
                        new Campanya { Nom = "Campanya Avis Deute", TipusCampanyaId = 2, DataCampanya = new DateTime(2022, 1, 1), Descripcio = "Campanya de avis de deute segon trimestre 2022", Observacions = "" },
                        new Campanya { Nom = "Campanya Cartes ", TipusCampanyaId = 3, DataCampanya = new DateTime(2022, 1, 1), Descripcio = "Campanya de cartes", Observacions = "" },
                        new Campanya { Nom = "Campanya Estalvi aigua", TipusCampanyaId = 4, DataCampanya = new DateTime(2022, 1, 1), Descripcio = "Campanya de concienciació de estalvi aigua", Observacions = "" },
                    };
                    await context.AddRangeAsync(campanyaData);
                    await context.SaveChangesAsync();
                }

                //anotacions campanyes
                if (!context.AnotacionsCampanyes!.Any())
                {
                    var anotacioCampanyesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\AnotacionsCampanyes.json");
                    var anotacionsCampanyes = JsonConvert.DeserializeObject<List<AnotacioCampanya>>(anotacioCampanyesData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.AnotacionsCampanyes!.AddRangeAsync(anotacionsCampanyes!);
                    await context.SaveChangesAsync();
                }

                //Canals Cobrament
                if (!context.CanalsCobrament!.Any())
                {
                    var canalsData = new List<CanalCobrament>()
                    {
                        new CanalCobrament(){Canal = "0000", Descripcio="finestreta", BIC = "", Observacions="", FormaPagament = FormaPagament.Finestreta},
                        new CanalCobrament(){Canal = "2100", Descripcio="Caixa Bank", BIC = "CCBKXX01", Observacions="", FormaPagament = FormaPagament.Domiciliat},
                        new CanalCobrament(){Canal = "0058", Descripcio="Caixa de Tarragona", BIC = "CCTARXX01", Observacions="", FormaPagament = FormaPagament.Domiciliat},
                        new CanalCobrament(){Canal = "0023", Descripcio="Bankia", BIC = "BKBKKXX01", Observacions="", FormaPagament = FormaPagament.Domiciliat},
                        new CanalCobrament(){Canal = "2150", Descripcio="Caixa de Manresa", BIC = "CCMNXX01", Observacions="", FormaPagament = FormaPagament.Domiciliat}
                    };
                    await context.CanalsCobrament!.AddRangeAsync(canalsData!);
                    await context.SaveChangesAsync();
                }
                //Carrers
                if (!context.Carrers!.Any())
                {
                    var carrerData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Carrers.json");
                    var carrer = JsonConvert.DeserializeObject<List<Carrer>>(carrerData);
                    await context.Carrers!.AddRangeAsync(carrer!);
                    await context.SaveChangesAsync();
                }
                // Tipus Comptador
                if (!context.TipusComptadors!.Any())
                {
                    var tipusComptadorData = new List<TipusComptador>()
                    {
                        new TipusComptador(){ Tipus = "Maneta", Descripcio= "Comptador classic de maneta", Observacions=""},
                        new TipusComptador(){ Tipus = "Volumetric", Descripcio="Comptador de volum", Observacions=""},
                        new TipusComptador(){ Tipus = "Radio", Descripcio="Comptador via ones hertzianes", Observacions=""},
                        new TipusComptador(){ Tipus = "Presostatic", Descripcio="Comptador per presio ultrabarica", Observacions=""}
                    };

                    await context.TipusComptadors.AddRangeAsync(tipusComptadorData);
                    await context.SaveChangesAsync();
                }

                // Marques Comptadors
                if (!context.MarquesComptadors!.Any())
                {
                    var marques = new List<MarcaComptador>()
                    {
                        new MarcaComptador{Marca = "ACME", Fabricant="Contagua", Observacions = ""},
                        new MarcaComptador{Marca = "AQUADOT", Fabricant="Contagua", Observacions = ""},
                        new MarcaComptador{Marca = "CYTRIX", Fabricant="Contazara", Observacions = ""},
                        new MarcaComptador{Marca = "MECAQUA", Fabricant="Contazara", Observacions = ""},
                        new MarcaComptador{Marca = "LUMIK", Fabricant="Contadores Gomez", Observacions = ""},
                        new MarcaComptador{Marca = "PARSONS", Fabricant="AquaService", Observacions = ""},
                        new MarcaComptador{Marca = "CONTH2O", Fabricant="Contadores Gomez", Observacions = ""},
                    };
                    await context.MarquesComptadors!.AddRangeAsync(marques!);
                    await context.SaveChangesAsync();
                }


                //Comptadors
                if (!context.Comptadors!.Any())
                {
                    var comptadorData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Comptadors.json");
                    var comptadors = JsonConvert.DeserializeObject<List<Comptador>>(comptadorData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd-MM-yyyy"
                    });
                    await context.Comptadors!.AddRangeAsync(comptadors!);
                    await context.SaveChangesAsync();
                }
                //Comptadors Ubicacio
                if (!context.ComptadorsUbicacio!.Any())
                {
                    var comptadorUbicacioData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ComptadorsUbicacions.json");
                    var comptadorsUbicacions = JsonConvert.DeserializeObject<List<ComptadorUbicacio>>(comptadorUbicacioData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ComptadorsUbicacio!.AddRangeAsync(comptadorsUbicacions!);
                    await context.SaveChangesAsync();
                }
                //Comptes Remesa Banc
                if (!context.ComptesRemesaBanc!.Any())
                {
                    var compteRemesaData = new List<CompteRemesaBanc>()
                    {
                        new CompteRemesaBanc
                            { IBAN = "ES2311112222334444444444", BIC = "ASDXX0021", Sufixe = "000", Activa = true, Descripcio = "Compte remesa 1", Observacions = "" },
                        new CompteRemesaBanc
                            { IBAN = "ES5665455345434366578787", BIC = "GTHYDXXX01", Sufixe = "000", Activa = true, Descripcio = "Compte remesa 2", Observacions = "" },
                        new CompteRemesaBanc
                            { IBAN = "ES5876687704786894847575", BIC = "BBCCXXM001", Sufixe = "000", Activa = true, Descripcio = "Compte remesa 3", Observacions = "" }
                    };
                    await context.AddRangeAsync(compteRemesaData);
                    await context.SaveChangesAsync();
                }
                //Comptes Transferencia Client
                if (!context.ComptesTransferenciaClient!.Any())
                {
                    var compteTransferenciaData = new List<CompteTransferenciaClient>()
                    {
                        new CompteTransferenciaClient
                            { IBAN = "ES5689786766576834334002", BIC = "AWXXXMC001", Activa = true, Descripcio = "Compte remesa 1", Observacions = "" },
                        new CompteTransferenciaClient
                            { IBAN = "ES6767454545787809060011", BIC = "BKPOMM0021", Activa = true, Descripcio = "Compte remesa 2", Observacions = "" },
                        new CompteTransferenciaClient
                            { IBAN = "ES4455667788990000212334", BIC = "GXCCDD0011", Activa = true, Descripcio = "Compte remesa 3", Observacions = "" }
                    };
                    await context.AddRangeAsync(compteTransferenciaData);
                    await context.SaveChangesAsync();
                }
                // Tipus Concepte factura
                if (!context.TipusConceptesFactura!.Any())
                {
                    var tipusConcepteFacturaData = new List<TipusConcepteFactura>()
                    {
                        new TipusConcepteFactura(){ Tipus = "HORA", Descripcio= "Hora ma d'obra operari", Observacions=""},
                        new TipusConcepteFactura(){ Tipus = "MATERIAL", Descripcio="Material", Observacions=""},
                        new TipusConcepteFactura(){ Tipus = "ANOTACIO", Descripcio="Anotacio Concepte Factura", Observacions=""},
                        new TipusConcepteFactura(){ Tipus = "AAA", Descripcio= "aaaaaaaaaaaaaaaaaaaaaa", Observacions=""},
                        new TipusConcepteFactura(){ Tipus = "BBB", Descripcio="bbbbbbbbbbbbbbbb", Observacions=""},
                        new TipusConcepteFactura(){ Tipus = "CCC", Descripcio="ccccccccccccccccccc", Observacions=""},
                    };

                    await context.TipusConceptesFactura.AddRangeAsync(tipusConcepteFacturaData);
                    await context.SaveChangesAsync();
                }
                // Familes Concepte Factura
                if (!context.FamiliesConcepteFactura!.Any())
                {
                    var familiesConcepteFacturaData = new List<FamiliaConcepteFactura>()
                    {
                        new FamiliaConcepteFactura(){ Familia = "HORES", Descripcio= "Hora ma d'obra operari", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "TUBS", Descripcio="Tubs", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "AIXETES", Descripcio="Aixetes", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "ARANDELES", Descripcio="Arandeles", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "COMPTADORS", Descripcio="Comptadors", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "CIMENT", Descripcio="Ciment", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "VALVULES", Descripcio="Valvules", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "CARGOLS", Descripcio="Cargols i tornilleria", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "SELLANTS", Descripcio="Materials sellants", Observacions=""},
                        new FamiliaConcepteFactura(){ Familia = "EXCAVADORA", Descripcio="Excavadora", Observacions=""},
                    };

                    await context.FamiliesConcepteFactura.AddRangeAsync(familiesConcepteFacturaData);
                    await context.SaveChangesAsync();
                }

                //Conceptes factura
                if (!context.ConceptesFactura!.Any())
                {
                    var conceptesFacturaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ConceptesFactura.json");
                    var conceptesFactura = JsonConvert.DeserializeObject<List<ConcepteFactura>>(conceptesFacturaData);
                    await context.ConceptesFactura!.AddRangeAsync(conceptesFactura!);
                    await context.SaveChangesAsync();
                }


                //Contactes Contracte
                if (!context.ContactesContracte!.Any())
                {
                    var contactesContracteData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ContactesContracte.json");
                    var contactesContracte = JsonConvert.DeserializeObject<List<ContacteContracte>>(contactesContracteData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ContactesContracte!.AddRangeAsync(contactesContracte!);
                    await context.SaveChangesAsync();
                }
                // Serveis Tarifa
                if (!context.ServeisTarifa!.Any())
                {
                    var serveis = new List<ServeiTarifa>()
                    {
                        new ServeiTarifa (){ Servei="AIGUA", Descripcio = "Abastament d'aigua", Observacions = ""},
                        new ServeiTarifa (){ Servei="CLAVEGUERAM", Descripcio = "Abastament d'aigua", Observacions = ""},
                        new ServeiTarifa (){ Servei="BASURA", Descripcio = "Abastament d'aigua", Observacions = ""},
                        new ServeiTarifa (){ Servei="CANON ACA", Descripcio = "Abastament d'aigua", Observacions = ""},
                    };
                    await context.ServeisTarifa!.AddRangeAsync(serveis!);
                    await context.SaveChangesAsync();
                }

                // Tarifes Servei
                if (!context.TarifesServei!.Any())
                {
                    var tarifesServeiData = new List<TarifaServei>()
                    {
                        new TarifaServei() { Tarifa = "Aigua Domestica", Descripcio = "", Observacions ="", ServeiTarifaId = 1, },
                        new TarifaServei() { Tarifa = "Aigua Industrial", Descripcio = "", Observacions ="", ServeiTarifaId = 1, },
                        new TarifaServei() { Tarifa = "Clavegueram Domestic", Descripcio = "", Observacions ="", ServeiTarifaId = 2, },
                        new TarifaServei() { Tarifa = "Clavegueram Industrial", Descripcio = "", Observacions ="", ServeiTarifaId = 2, },
                        new TarifaServei() { Tarifa = "Basura Domestica", Descripcio = "", Observacions ="", ServeiTarifaId = 3, },
                        new TarifaServei() { Tarifa = "Basura Industrial", Descripcio = "", Observacions ="", ServeiTarifaId = 3, },
                        new TarifaServei() { Tarifa = "Canon Domestica", Descripcio = "", Observacions ="", ServeiTarifaId = 4, },
                        new TarifaServei() { Tarifa = "Canon Industrial", Descripcio = "", Observacions ="", ServeiTarifaId = 4, },
                    };

                    await context.TarifesServei.AddRangeAsync(tarifesServeiData);
                    await context.SaveChangesAsync();
                }
                //Contractes tarifa Servei
                if (!context.ContractesTarifaServei!.Any())
                {
                    var contractesTarifaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ContractesTarifa1.json");
                    var contractesTarifa = JsonConvert.DeserializeObject<List<ContracteTarifaServei>>(contractesTarifaData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ContractesTarifaServei!.AddRangeAsync(contractesTarifa!);

                    var contractesTarifaData2 = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ContractesTarifa2.json");
                    var contractesTarifa2 = JsonConvert.DeserializeObject<List<ContracteTarifaServei>>(contractesTarifaData2, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ContractesTarifaServei!.AddRangeAsync(contractesTarifa2!);

                    var contractesTarifaData3 = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ContractesTarifa3.json");
                    var contractesTarifa3 = JsonConvert.DeserializeObject<List<ContracteTarifaServei>>(contractesTarifaData3, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ContractesTarifaServei!.AddRangeAsync(contractesTarifa3!);

                    var contractesTarifaData4 = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\ContractesTarifa4.json");
                    var contractesTarifa4 = JsonConvert.DeserializeObject<List<ContracteTarifaServei>>(contractesTarifaData4, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.ContractesTarifaServei!.AddRangeAsync(contractesTarifa4!);
                    await context.SaveChangesAsync();
                }

                //Detalls Factura
                if (!context.DetallsFactura!.Any())
                {
                    var detallFacturaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\DetallFactures.json");
                    var detallsFactura = JsonConvert.DeserializeObject<List<DetallFactura>>(detallFacturaData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.DetallsFactura!.AddRangeAsync(detallsFactura!);
                    await context.SaveChangesAsync();
                }

                //Detalls Rebut


                //Detalls OT
                if (!context.DetallsOrdresTreball!.Any())
                {
                    var detallOTData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\DetallOTs.json");
                    var detallOT = JsonConvert.DeserializeObject<List<DetallOrdreTreball>>(detallOTData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.DetallsOrdresTreball!.AddRangeAsync(detallOT!);
                    await context.SaveChangesAsync();
                }

                // Tipus Document
                if (!context.TipusDocuments!.Any())
                {
                    var tipusDocumentData = new List<TipusDocument>()
                    {
                        new TipusDocument(){ Tipus = "Imatge", Descripcio= "Imatge fotografica", Observacions=""},
                        new TipusDocument(){ Tipus = "Contracte", Descripcio="Contracte de subministrament", Observacions=""},
                        new TipusDocument(){ Tipus = "Factura", Descripcio="Factura de taller", Observacions=""},
                        new TipusDocument(){ Tipus = "Rebut", Descripcio="Rebut d'aigua", Observacions=""},
                        new TipusDocument(){ Tipus = "Escriptura", Descripcio="Escriptura de propietat", Observacions=""},
                        new TipusDocument(){ Tipus = "Llicencia Obres", Descripcio="Llicencia obres temporal", Observacions=""},
                        new TipusDocument(){ Tipus = "Cedula", Descripcio="Cedula d'habitabilitat", Observacions=""}
                    };

                    await context.TipusDocuments.AddRangeAsync(tipusDocumentData);
                    await context.SaveChangesAsync();
                }
                //Documents
                if (!context.Documents!.Any())
                {
                    var documentsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Documents.json");
                    var documents = JsonConvert.DeserializeObject<List<Document>>(documentsData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.Documents!.AddRangeAsync(documents!);
                    await context.SaveChangesAsync();
                }
                //Empresa
                if (!context.Empreses!.Any())
                {
                    var empresesData = new List<Empresa>()
                    {
                        new Empresa(){ NomEmpresa = "Aigues del Matarranya", NomCurtEmpresa = "AiguesMata", CIF = "F34523784", Direccio = "Carrer del Mig, 34", CP =      "08765", Poblacio = "Deltebre", Provincia = "Tarragona", Telefon = "977345563", Mobil = "609654372", Email =                          "aiguesmatarranya@gmail.com", WWW = "www.aiguesmatarranya.cat", Observacions = "" },
                        new Empresa() { NomEmpresa = "Ajuntament de Delebre", NomCurtEmpresa = "AjuDeltebre", CIF = "F5644343A", Direccio = "Plaça Major, 1", CP = "08765", Poblacio = "Deltebre", Provincia = "Tarragona", Telefon = "977767677", Mobil = "608564354", Email = "ajdeltebre@diba.cat", WWW = "www.ajdeltebre.cat", Observacions = "" },
                        new Empresa() { NomEmpresa = "Associacio Catalana de l'Aigua", NomCurtEmpresa = "ACA", CIF = "F09090909", Direccio = "Carrer Rosello, 23-4-1", CP = "08800", Poblacio = "Barcelona", Provincia = "Barceloan", Telefon = "256345476", Mobil = "609876567", Email = "aca@gencat.cat", WWW = "www.aca.cat", Observacions = "" }
                    };
                    await context.AddRangeAsync(empresesData);
                    await context.SaveChangesAsync();
                }

                //Entregues a Compte
                if (!context.EntreguesACompte!.Any())
                {
                    var entreguesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\EntreguesACompte.json");
                    var entregues = JsonConvert.DeserializeObject<List<EntregaACompte>>(entreguesData, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy"
                    });
                    await context.EntreguesACompte!.AddRangeAsync(entregues!);
                    await context.SaveChangesAsync();
                }
                // Tipus Incidencia Client
                if (!context.TipusIncidenciesClient!.Any())
                {
                    var tipusIncidenciaClientData = new List<TipusIncidenciaClient>()
                    {
                        new TipusIncidenciaClient(){ Tipus = "Inc1", Descripcio="Incidencia client 1", Observacions=""},
                        new TipusIncidenciaClient(){ Tipus = "Inc2", Descripcio="Incidencia client 2", Observacions=""},
                        new TipusIncidenciaClient(){ Tipus = "Inc3", Descripcio="Incidencia client 3", Observacions=""},
                        new TipusIncidenciaClient(){ Tipus = "Inc4", Descripcio="Incidencia client 4", Observacions=""},
                        new TipusIncidenciaClient(){ Tipus = "Inc5", Descripcio="Incidencia client 5", Observacions=""},
                        new TipusIncidenciaClient(){ Tipus = "Inc6", Descripcio="Incidencia client 6", Observacions=""},
                    };

                    await context.TipusIncidenciesClient.AddRangeAsync(tipusIncidenciaClientData);
                    await context.SaveChangesAsync();
                }
                // Tipus Incidencia Contracte
                if (!context.TipusIncidenciesContracte!.Any())
                {
                    var tipusIncidenciaContracteData = new List<TipusIncidenciaContracte>()
                    {
                        new TipusIncidenciaContracte(){ Tipus = "Inc1", Descripcio="Incidencia contracte 1", Observacions=""},
                        new TipusIncidenciaContracte(){ Tipus = "Inc2", Descripcio="Incidencia contracte 2", Observacions=""},
                        new TipusIncidenciaContracte(){ Tipus = "Inc3", Descripcio="Incidencia contracte 3", Observacions=""},
                        new TipusIncidenciaContracte(){ Tipus = "Inc4", Descripcio="Incidencia contracte 4", Observacions=""},
                        new TipusIncidenciaContracte(){ Tipus = "Inc5", Descripcio="Incidencia contracte 5", Observacions=""},
                        new TipusIncidenciaContracte(){ Tipus = "Inc6", Descripcio="Incidencia contracte 6", Observacions=""},
                    };

                    await context.TipusIncidenciesContracte.AddRangeAsync(tipusIncidenciaContracteData);
                    await context.SaveChangesAsync();
                }
                // Tipus Incidencia Lectura
                if (!context.TipusIncidenciesLectura!.Any())
                {
                    var tipusIncidenciaLecturaData = new List<TipusIncidenciaLectura>()
                    {
                        new TipusIncidenciaLectura(){ Tipus = "Inc1", ConsumApte = true, ConsumImputar = true, Opcio = 'N', Descripcio="Incidencia lectura tipus 1", Observacions=""},
                        new TipusIncidenciaLectura(){ Tipus = "Inc2", ConsumApte = true,ConsumImputar = true, Opcio = 'N',Descripcio="Incidencia lectura tipus 2", Observacions=""},
                        new TipusIncidenciaLectura(){ Tipus = "Inc3", ConsumApte = false,ConsumImputar = true, Opcio = 'D',Descripcio="Incidencia lectura tipus 3", Observacions=""},
                        new TipusIncidenciaLectura(){ Tipus = "Inc4", ConsumApte = true,ConsumImputar = false, Opcio = 'N',Descripcio="Incidencia lectura tipus 4", Observacions=""},
                        new TipusIncidenciaLectura(){ Tipus = "Inc5", ConsumApte = true,ConsumImputar = true, Opcio = 'D',Descripcio="Incidencia lectura tipus 5", Observacions=""},
                        new TipusIncidenciaLectura(){ Tipus = "Inc6", ConsumApte = true,ConsumImputar = true, Opcio = 'N',Descripcio="Incidencia lectura tipus 6", Observacions=""},
                    };

                    await context.TipusIncidenciesLectura.AddRangeAsync(tipusIncidenciaLecturaData);
                    await context.SaveChangesAsync();
                }
                // Tipus Incidencia Tecnica
                if (!context.TipusIncidenciesTecnica!.Any())
                {
                    var tipusIncidenciaTecnicaData = new List<TipusIncidenciaTecnica>()
                    {
                        new TipusIncidenciaTecnica(){ Tipus = "Inc1", Descripcio="Incidencia tecnica tipus 1", Observacions=""},
                        new TipusIncidenciaTecnica(){ Tipus = "Inc2", Descripcio="Incidencia tecnica tipus 2", Observacions=""},
                        new TipusIncidenciaTecnica(){ Tipus = "Inc3", Descripcio="Incidencia tecnica tipus 3", Observacions=""},
                        new TipusIncidenciaTecnica(){ Tipus = "Inc4", Descripcio="Incidencia tecnica tipus 4", Observacions=""},
                        new TipusIncidenciaTecnica(){ Tipus = "Inc5", Descripcio="Incidencia tecnica tipus 5", Observacions=""},
                        new TipusIncidenciaTecnica(){ Tipus = "Inc6", Descripcio="Incidencia tecnica tipus 6", Observacions=""},
                    };

                    await context.TipusIncidenciesTecnica.AddRangeAsync(tipusIncidenciaTecnicaData);
                    await context.SaveChangesAsync();
                }
                // Tipus Incidencia Ubicacio
                if (!context.TipusIncidenciesUbicacio!.Any())
                {
                    var tipusIncidenciaUbicacioData = new List<TipusIncidenciaUbicacio>()
                    {
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc1", Descripcio="Incidencia Ubicacio tipus 1", Observacions=""},
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc2", Descripcio="Incidencia Ubicacio tipus 2", Observacions=""},
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc3", Descripcio="Incidencia Ubicacio tipus 3", Observacions=""},
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc4", Descripcio="Incidencia Ubicacio tipus 4", Observacions=""},
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc5", Descripcio="Incidencia Ubicacio tipus 5", Observacions=""},
                        new TipusIncidenciaUbicacio(){ Tipus = "Inc6", Descripcio="Incidencia Ubicacio tipus 6", Observacions=""},
                    };

                    await context.TipusIncidenciesUbicacio.AddRangeAsync(tipusIncidenciaUbicacioData);
                    await context.SaveChangesAsync();
                }
                // Incidencies Clients
                if (!context.IncidenciesClient!.Any())
                {
                    var incidenciesClientData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\IncidenciesClient.json");
                    var incidenciesClient = JsonConvert.DeserializeObject<List<IncidenciaClient>>(incidenciesClientData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.IncidenciesClient!.AddRangeAsync(incidenciesClient!);
                    await context.SaveChangesAsync();
                }
                // Incidencies Contractes
                if (!context.IncidenciesContracte!.Any())
                {
                    var incidenciesContracteData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\IncidenciesContracte.json");
                    var incidenciesContracte = JsonConvert.DeserializeObject<List<IncidenciaContracte>>(incidenciesContracteData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.IncidenciesContracte!.AddRangeAsync(incidenciesContracte!);
                    await context.SaveChangesAsync();
                }
                // Incidencies Tecniques
                if (!context.IncidenciesTecniques!.Any())
                {
                    var incidenciesTecniquesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\IncidenciesTecniques.json");
                    var incidenciesTecniques = JsonConvert.DeserializeObject<List<IncidenciaTecnica>>(incidenciesTecniquesData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.IncidenciesTecniques!.AddRangeAsync(incidenciesTecniques!);
                    await context.SaveChangesAsync();
                }
                // Incidencies Ubicacions
                if (!context.IncidenciesUbicacio!.Any())
                {
                    var incidenciesUbicacionsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\IncidenciesUbicacio.json");
                    var incidenciesUbicacions = JsonConvert.DeserializeObject<List<IncidenciaUbicacio>>(incidenciesUbicacionsData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.IncidenciesUbicacio!.AddRangeAsync(incidenciesUbicacions!);
                    await context.SaveChangesAsync();
                }

                // Lectures
                if (!context.Lectures!.Any())
                {
                    var lecturesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Lectures.json");
                    var lectures = JsonConvert.DeserializeObject<List<Lectura>>(lecturesData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.Lectures!.AddRangeAsync(lectures!);
                    await context.SaveChangesAsync();
                }
                // Lectures Comptadors
                if (!context.LecturesComptador!.Any())
                {
                    var lecturesComptadorData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\LecturesComptador.json");
                    var lecturesComptador = JsonConvert.DeserializeObject<List<LecturaComptador>>(lecturesComptadorData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.LecturesComptador!.AddRangeAsync(lecturesComptador!);
                    await context.SaveChangesAsync();
                }


                // Motius Baixa Titulars
                if (!context.MotiusBaixaTitular!.Any())
                {
                    var motiusBaixaTitularData = new List<MotiuBaixaTitular>()
                    {
                        new MotiuBaixaTitular() { Motiu = "Voluntaria", Observacions = "" },
                        new MotiuBaixaTitular() { Motiu = "Defunció", Observacions = "" },
                        new MotiuBaixaTitular() { Motiu = "Tecnica", Observacions = "" },
                        new MotiuBaixaTitular() { Motiu = "Baixa Contracte", Observacions = "" },
                        new MotiuBaixaTitular() { Motiu = "Canvi Nom", Observacions = "" },
                        new MotiuBaixaTitular() { Motiu = "Varis", Observacions = "" },
                    };
                    await context.MotiusBaixaTitular!.AddRangeAsync(motiusBaixaTitularData!);
                    await context.SaveChangesAsync();
                }
                // Motius Baixa Titulars Compte
                if (!context.MotiusBaixaCompte!.Any())
                {
                    var motiusBaixaCompteData = new List<MotiuBaixaCompte>()
                    {
                        new MotiuBaixaCompte() { Motiu = "Voluntaria", Observacions = "" },
                        new MotiuBaixaCompte() { Motiu = "Defunció", Observacions = "" },
                        new MotiuBaixaCompte() { Motiu = "Tecnica", Observacions = "" },
                        new MotiuBaixaCompte() { Motiu = "Baixa Contracte", Observacions = "" },
                        new MotiuBaixaCompte() { Motiu = "Canvi Compte", Observacions = "" },
                        new MotiuBaixaCompte() { Motiu = "Impagament", Observacions = "" },
                    };
                    await context.MotiusBaixaCompte!.AddRangeAsync(motiusBaixaCompteData!);
                    await context.SaveChangesAsync();
                }

                // Operaris Ordre
                if (!context.OperarisOrdre!.Any())
                {
                    var operarisOTData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\OperarisOT.json");
                    var operarisOT = JsonConvert.DeserializeObject<List<OperariOrdre>>(operarisOTData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.OperarisOrdre!.AddRangeAsync(operarisOT!);
                    await context.SaveChangesAsync();
                }
                // Partides Tarifa
                if (!context.PartidesTarifa!.Any())
                {
                    var partidesTarifaData = new List<PartidaTarifa>()
                    {
                        new PartidaTarifa(){ Partida = "Partida1", Descripcio="Partida numero 1", Observacions=""},
                        new PartidaTarifa(){ Partida = "Partida2", Descripcio="Partida numero 2", Observacions=""},
                        new PartidaTarifa(){ Partida = "Partida3", Descripcio="Partida numero 3", Observacions=""},
                        new PartidaTarifa(){ Partida = "Partida4", Descripcio="Partida numero 4", Observacions=""},
                        new PartidaTarifa(){ Partida = "Partida5", Descripcio="Partida numero 5", Observacions=""},
                        new PartidaTarifa(){ Partida = "Partida6", Descripcio="Partida numero 6", Observacions=""},
                    };

                    await context.PartidesTarifa.AddRangeAsync(partidesTarifaData);
                    await context.SaveChangesAsync();
                }
                // Tipus Queixa
                if (!context.TipusQueixes!.Any())
                {
                    var tipusQueixaData = new List<TipusQueixa>()
                    {
                        new TipusQueixa(){ Tipus = "Lectura", Descripcio="Queixa en la lectura", Observacions=""},
                        new TipusQueixa(){ Tipus = "Rebut", Descripcio="Queixa en el rebut", Observacions=""},
                        new TipusQueixa(){ Tipus = "Factura", Descripcio="Queixa en una factura", Observacions=""},
                        new TipusQueixa(){ Tipus = "Servei", Descripcio="Queixa en el servei atencio", Observacions=""},
                        new TipusQueixa(){ Tipus = "Obra", Descripcio="Queixa en una obra", Observacions=""},
                        new TipusQueixa(){ Tipus = "Comptador", Descripcio="Queixa del comptador", Observacions=""},
                    };

                    await context.TipusQueixes.AddRangeAsync(tipusQueixaData);
                    await context.SaveChangesAsync();
                }
                // Tipus Reclamacio
                if (!context.TipusReclamacions!.Any())
                {
                    var tipusReclamacioData = new List<TipusReclamacio>()
                    {
                        new TipusReclamacio(){ Tipus = "Lectura", Descripcio="Reclamació en la lectura", Observacions=""},
                        new TipusReclamacio(){ Tipus = "Rebut", Descripcio="Reclamació en el rebut", Observacions=""},
                        new TipusReclamacio(){ Tipus = "Factura", Descripcio="Reclamació en una factura", Observacions=""},
                    };

                    await context.TipusReclamacions.AddRangeAsync(tipusReclamacioData);
                    await context.SaveChangesAsync();
                }
                // Tipus Suggeriment
                if (!context.TipusSuggeriment!.Any())
                {
                    var tipusSuggerimentData = new List<TipusSuggeriment>()
                    {
                        new TipusSuggeriment(){ Tipus = "Servei", Descripcio= "Millora en el servei", Observacions=""},
                        new TipusSuggeriment(){ Tipus = "Oficina Virtual", Descripcio="Millora en la OV", Observacions=""},
                        new TipusSuggeriment(){ Tipus = "Rebut", Descripcio="Millora en el rebut", Observacions=""},
                    };

                    await context.TipusSuggeriment.AddRangeAsync(tipusSuggerimentData);
                    await context.SaveChangesAsync();
                }
                // Queixes
                if (!context.Queixes!.Any())
                {
                    var queixesData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Queixes.json");
                    var queixes = JsonConvert.DeserializeObject<List<Queixa>>(queixesData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.Queixes!.AddRangeAsync(queixes!);
                    await context.SaveChangesAsync();
                }



                // Reclamacions
                if (!context.Reclamacions!.Any())
                {
                    var reclamacionsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Reclamacions.json");
                    var reclamacions = JsonConvert.DeserializeObject<List<Reclamacio>>(reclamacionsData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.Reclamacions!.AddRangeAsync(reclamacions!);
                    await context.SaveChangesAsync();
                }




                // Solicituds Alta
                if (!context.SolicitudsAlta!.Any())
                {
                    var solicitudsAltaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\SolicitudsAlta.json");
                    var solicitudsAlta = JsonConvert.DeserializeObject<List<SolicitudAlta>>(solicitudsAltaData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.SolicitudsAlta!.AddRangeAsync(solicitudsAlta!);
                    await context.SaveChangesAsync();
                }
                // Tipus baixa Client
                if (!context.TipusBaixaClients!.Any())
                {
                    var tipusBaixaClientData = new List<TipusBaixaClient>()
                    {
                        new TipusBaixaClient(){ TipusBaixa = "Voluntaria", Descripcio= "Baixa Voluntaria", Observacions=""},
                        new TipusBaixaClient(){ TipusBaixa = "Impagament", Descripcio="Baixa per deute", Observacions=""},
                        new TipusBaixaClient(){ TipusBaixa = "Defunció", Descripcio="Baixa per RIP", Observacions=""},
                        new TipusBaixaClient(){ TipusBaixa = "Altres", Descripcio="Baixa per altres motius", Observacions=""}
                    };

                    await context.TipusBaixaClients.AddRangeAsync(tipusBaixaClientData);
                    await context.SaveChangesAsync();
                }
                // Solicituds Baixa
                if (!context.SolicitudsBaixa!.Any())
                {
                    var solicitudsBaixaData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\SolicitudsBaixa.json");
                    var solicitudsBaixa = JsonConvert.DeserializeObject<List<SolicitudBaixa>>(solicitudsBaixaData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.SolicitudsBaixa!.AddRangeAsync(solicitudsBaixa!);
                    await context.SaveChangesAsync();
                }

                // Suggeriments
                if (!context.Suggeriments!.Any())
                {
                    var suggerimentsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\Suggeriments.json");
                    var suggeriments = JsonConvert.DeserializeObject<List<Suggeriment>>(suggerimentsData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });

                    await context.Suggeriments!.AddRangeAsync(suggeriments!);
                    await context.SaveChangesAsync();
                }
                //Conceptes tarifa
                if (!context.ConceptesTarifa!.Any())
                {
                    var conceptesTarifaData = new List<ConcepteTarifa>()
                    {
                        new ConcepteTarifa{Descripcio = "Aigua", Observacions = "", Ordre = 1, Actiu = true, EmpresaId = 1, CodiComptable = "C0001"},
                        new ConcepteTarifa{Descripcio = "Quota Aigua", Observacions = "", Ordre = 2, Actiu = true, EmpresaId = 1, CodiComptable = "C0002"},
                        new ConcepteTarifa{Descripcio = "Clavegueram", Observacions = "", Ordre = 3, Actiu = true, EmpresaId = 1, CodiComptable = "C0003"},
                        new ConcepteTarifa{Descripcio = "Quota Clavegueram", Observacions = "", Ordre = 4, Actiu = true, EmpresaId = 1, CodiComptable = "C0004"},
                        new ConcepteTarifa{Descripcio = "Basura", Observacions = "", Ordre = 5, Actiu = true, EmpresaId = 2, CodiComptable = "C0005"},
                        new ConcepteTarifa{Descripcio = "Quota Basura", Observacions = "", Ordre = 6, Actiu = true, EmpresaId = 2, CodiComptable = "C0006"},
                        new ConcepteTarifa{Descripcio = "Canon Variable", Observacions = "", Ordre = 7, Actiu = true, EmpresaId = 3, CodiComptable = "C0007"},
                        new ConcepteTarifa{Descripcio = "Canon Fix", Observacions = "", Ordre = 8, Actiu = true, EmpresaId = 3, CodiComptable = "C0008"},
                    };
                    await context.ConceptesTarifa.AddRangeAsync(conceptesTarifaData);
                    await context.SaveChangesAsync();
                }
                // Subconceptes Tarifa
                if (!context.SubconceptesTarifa!.Any())
                {
                    var subconceptesTarifaData = new List<SubconcepteTarifa>()
                    {
                        new SubconcepteTarifa() { Subconcepte = "Abastament Domestic", Versio = 1, Descripcio ="", Valor = 5.5675, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 1, TarifaServeiId = 1 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Domestica", Versio = 1, Descripcio ="", Valor = 12.45, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 2, TarifaServeiId = 1 },
                        new SubconcepteTarifa() { Subconcepte = "Abastament Industrial", Versio = 1, Descripcio ="", Valor = 8.4543, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 1, TarifaServeiId = 2 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Industrial", Versio = 1, Descripcio ="", Valor = 19.75, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 2, TarifaServeiId = 2 },

                        new SubconcepteTarifa() { Subconcepte = "Clavegueram Domestic", Versio = 1, Descripcio ="", Valor = 5.5675, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 3, TarifaServeiId = 3 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Clavegueram Domestica", Versio = 1, Descripcio ="", Valor = 12.45, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 4, TarifaServeiId = 3 },
                        new SubconcepteTarifa() { Subconcepte = "Clavegueram Industrial", Versio = 1, Descripcio ="", Valor = 8.4543, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 3, TarifaServeiId = 4 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Clavegueram Industrial", Versio = 1, Descripcio ="", Valor = 19.75, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 4, TarifaServeiId = 4 },

                        new SubconcepteTarifa() { Subconcepte = "Basura Domestica", Versio = 1, Descripcio ="", Valor = 3.10, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 5, TarifaServeiId = 5 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Basura Domestica", Versio = 1, Descripcio ="", Valor = 5.45, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 6, TarifaServeiId = 5 },
                        new SubconcepteTarifa() { Subconcepte = "Basura Industrial", Versio = 1, Descripcio ="", Valor = 7.56, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 5, TarifaServeiId = 6 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Fixe Basura Industrial", Versio = 1, Descripcio ="", Valor = 10.75, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 6, TarifaServeiId = 6 },

                        new SubconcepteTarifa() { Subconcepte = "Canon Domestica", Versio = 1, Descripcio ="", Valor = 3.10, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 7, TarifaServeiId = 7 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Canon Domestica", Versio = 1, Descripcio ="", Valor = 5.45, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 8, TarifaServeiId = 7 },
                        new SubconcepteTarifa() { Subconcepte = "Canon Industrial", Versio = 1, Descripcio ="", Valor = 7.56, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Variable_Blocs, Taxa = 7, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.m3, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.bimestral, ConcepteTarifaId = 7, TarifaServeiId = 8 },
                        new SubconcepteTarifa() { Subconcepte = "Quota Canon Industrial", Versio = 1, Descripcio ="", Valor = 10.75, Minim = 0, Exempt = 0, Bonificacio = 0, TipusSubconcepte = TipusSubconcepteTarifa.Fixe, Taxa = 10, DataAprovacio = DateTime.UtcNow, DataAplicacio = DateTime.UtcNow, DataCaducitat = null, Actiu = true, Unitats = Unitat.eur, Demora = false, Prorratejable = true,  Periode = PeriodeFacturacio.mensual, ConcepteTarifaId = 8, TarifaServeiId = 8 },
                    };

                    await context.SubconceptesTarifa.AddRangeAsync(subconceptesTarifaData);
                    await context.SaveChangesAsync();
                }

                // Blocs Tarifa
                if (!context.BlocsTarifa!.Any())
                {
                    var blocsTarifaData = new List<BlocTarifa>()
                    {
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Aigua Domestic", Valor = 5, Preu = 6.3452m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 1},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Aigua Domestic", Valor = 20, Preu = 12.52m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 1},
                        new BlocTarifa() { Bloc = 3, Versio = 1, Descripcio = "Bloc 3 Aigua Domestic", Valor = 9999, Preu = 21.32m, Ordre = 3, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 1},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Aigua Industrial", Valor = 5, Preu = 16.3452m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 3},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Aigua Industrial", Valor = 5, Preu = 26.32m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 3},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Clavegueram Domestic", Valor = 20, Preu = 7.8m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 5},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Clavegueram Domestic", Valor = 9999, Preu = 13.78m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 5},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Clavegueram Industrial", Valor = 10, Preu = 15.89m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 7},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Clavegueram Industrial", Valor = 9999, Preu = 25.8976m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 7},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Basura Domestic", Valor = 5, Preu = 6.3452m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 9},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Basura Domestic", Valor = 20, Preu = 12.52m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 9},
                        new BlocTarifa() { Bloc = 3, Versio = 1, Descripcio = "Bloc 3 Basura Domestic", Valor = 9999, Preu = 21.32m, Ordre = 3, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 9},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Basura Industrial", Valor = 5, Preu = 16.3452m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 11},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Basura Industrial", Valor = 9999, Preu = 26.32m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 11},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Canon Domestic", Valor = 10, Preu = 7.8m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 13},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Canon Domestic", Valor = 20, Preu = 10.768m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 13},
                        new BlocTarifa() { Bloc = 3, Versio = 1, Descripcio = "Bloc 3 Canon Domestic", Valor = 9999, Preu = 13.348m, Ordre = 3, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 13},
                        new BlocTarifa() { Bloc = 1, Versio = 1, Descripcio = "Bloc 1 Canon Industrial", Valor = 15, Preu = 15.89m, Ordre = 1, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 15},
                        new BlocTarifa() { Bloc = 2, Versio = 1, Descripcio = "Bloc 2 Canon Industrial", Valor = 25, Preu = 30.876m, Ordre = 2, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 15},
                        new BlocTarifa() { Bloc = 3, Versio = 1, Descripcio = "Bloc 3 Canon Industrial", Valor = 9999, Preu = 45.76m, Ordre = 3, Actiu = true, M3Adicionals = 0, SubconcepteTarifaId = 15},
                    };

                    await context.BlocsTarifa.AddRangeAsync(blocsTarifaData);
                    await context.SaveChangesAsync();

                }

                // Subconceptes Tarifa partida



                // Titulars Compte Contracte
                if (!context.TitularsCompteContracte!.Any())
                {
                    var titularCompteData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\TitularsCompteContracte.json");
                    var titularsCompte = JsonConvert.DeserializeObject<List<TitularCompteContracte>>(titularCompteData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.TitularsCompteContracte!.AddRangeAsync(titularsCompte!);
                    await context.SaveChangesAsync();
                }

                // Titulars Contracte
                if (!context.TitularsContracte!.Any())
                {
                    var titularsData = File.ReadAllText("C:\\ProjectesVS\\AquaProWeb\\AquaProWeb.Infrastructure\\DataSeed\\TitularsContracte.json");
                    var titulars = JsonConvert.DeserializeObject<List<TitularContracte>>(titularsData, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
                    await context.TitularsContracte!.AddRangeAsync(titulars!);
                    await context.SaveChangesAsync();
                }




            }
            catch (Exception ex)
            {

            }

        }
    }
}
