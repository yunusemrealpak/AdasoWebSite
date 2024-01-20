using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<AlbumGorselleriManager>().As<IAlbumGorselleriService>();
            builder.RegisterType<EfAlbumGorselleriDal>().As<IAlbumGorselleriDal>();

            builder.RegisterType<AlbumlerManager>().As<IAlbumlerService>();
            builder.RegisterType<EfAlbumlerDal>().As<IAlbumlerDal>();

            builder.RegisterType<AnketlerManager>().As<IAnketlerService>();
            builder.RegisterType<EfAnketlerDal>().As<IAnketlerDal>();

            builder.RegisterType<AnketSecenekleriManager>().As<IAnketSecenekleriService>();
            builder.RegisterType<EfAnketSecenekleriDal>().As<IAnketSecenekleriDal>();

            builder.RegisterType<BaglantilarManager>().As<IBaglantilarService>();
            builder.RegisterType<EfBaglantilarDal>().As<IBaglantilarDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<EIPManager>().As<IEIPService>();
            builder.RegisterType<EfEIPDal>().As<IEIPDal>();

            builder.RegisterType<EtkinliklerManager>().As<IEtkinliklerService>();
            builder.RegisterType<EfEtkinliklerDal>().As<IEtkinliklerDal>();

            builder.RegisterType<FireKararlariManager>().As<IFireKararlariService>();
            builder.RegisterType<EfFireKararlariDal>().As<IFireKararlariDal>();

            builder.RegisterType<GazetelerManager>().As<IGazetelerService>();
            builder.RegisterType<EfGazetelerDal>().As<IGazetelerDal>();

            builder.RegisterType<IslemGecmisHareketleriManager>().As<IIslemGecmisHareketleriService>();
            builder.RegisterType<EfIslemGecmisHareketleriDal>().As<IIslemGecmisHareketleriDal>();

            builder.RegisterType<KullanicilarManager>().As<IKullanicilarService>();
            builder.RegisterType<EfKullanicilarDal>().As<IKullanicilarDal>();

            builder.RegisterType<MKUyelerManager>().As<IMKUyelerService>();
            builder.RegisterType<EfMKUyelerDal>().As<IMKUyelerDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<ProjelerManager>().As<IProjelerService>();
            builder.RegisterType<EfProjelerDal>().As<IProjelerDal>();

            builder.RegisterType<RaporlarManager>().As<IRaporlarService>();
            builder.RegisterType<EfRaporlarDal>().As<IRaporlarDal>();

            builder.RegisterType<SayfalarManager>().As<ISayfalarService>();
            builder.RegisterType<EfSayfalarDal>().As<ISayfalarDal>();

            builder.RegisterType<TDHaberlerManager>().As<ITDHaberlerService>();
            builder.RegisterType<EfTDHaberlerDal>().As<ITDHaberlerDal>();

            builder.RegisterType<TebliglerManager>().As<ITebliglerService>();
            builder.RegisterType<EfTebliglerDal>().As<ITebliglerDal>();

            builder.RegisterType<YazilarManager>().As<IYazilarService>();
            builder.RegisterType<EfYazilarDal>().As<IYazilarDal>();

            builder.RegisterType<YoutubeManager>().As<IYoutubeService>();
            builder.RegisterType<EfYoutubeDal>().As<IYoutubeDal>();

            builder.RegisterType<SunumlarManager>().As<ISunumlarService>();
            builder.RegisterType<EfSunumlarDal>().As<ISunumlarDal>();

            builder.RegisterType<Crs_Sunumlar_SonucManager>().As<ICrs_Sunumlar_SonucService>();
            builder.RegisterType<EfCrs_Sunumlar_SonucDal>().As<ICrs_Sunumlar_SonucDal>();


            builder.RegisterType<MesajKuyruklarManager>().As<IMesajKuyruklarService>();
            builder.RegisterType<EfMesajKuyruklarDal>().As<IMesajKuyruklarDal>();

            builder.RegisterType<view_MeslekGruplariManager>().As<Iview_MeslekGruplariService>();
            builder.RegisterType<Efview_MeslekGruplariDal>().As<Iview_MeslekGruplariDal>();

            builder.RegisterType<view_Uye_BilgileriManager>().As<Iview_Uye_BilgileriService>();
            builder.RegisterType<Efview_Uye_BilgileriDal>().As<Iview_Uye_BilgileriDal>();

            builder.RegisterType<view_TemsilcilerManager>().As<Iview_TemsilcilerService>();
            builder.RegisterType<Efview_TemsilcilerDal>().As<Iview_TemsilcilerDal>();

            builder.RegisterType<view_ortaklikManager>().As<Iview_ortaklikService>();
            builder.RegisterType<Efview_ortaklikDal>().As<Iview_ortaklikDal>();

            builder.RegisterType<DosyaYonetimiManager>().As<IDosyaYonetimiService>();
            builder.RegisterType<EfDosyaYonetimiDal>().As<IDosyaYonetimiDal>();

            builder.RegisterType<View_Base_Hedef_Tekrar_GetirManager>().As<IView_Base_Hedef_Tekrar_GetirService>();
            builder.RegisterType<EfView_Base_Hedef_Tekrar_GetirDal>().As<IView_Base_Hedef_Tekrar_GetirDal>();

            builder.RegisterType<proc_Adaso_org_tr_GenelAramaManager>().As<Iproc_Adaso_org_tr_GenelAramaService>();
            builder.RegisterType<Efproc_Adaso_org_tr_GenelAramaDal>().As<Iproc_Adaso_org_tr_GenelAramaDal>();

            builder.RegisterType<view_UyeUyelikSabitTelefonManager>().As<Iview_UyeUyelikSabitTelefonService>();
            builder.RegisterType<Efview_UyeUyelikSabitTelefonDal>().As<Iview_UyeUyelikSabitTelefonDal>();

            builder.RegisterType<MobilVersiyonKontrolManager>().As<IMobilVersiyonKontrolService>();
            builder.RegisterType<EfMobilVersiyonKontrolDal>().As<IMobilVersiyonKontrolDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
