using CharacterOptionsPlus.Util;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Utility;
using Mesmerist.Mesmerist;
using System;
using System.Collections.Generic;
using System.Linq;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace Mesmerist.Utils
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class Guids
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(Guids));

        #region Mesmerist
        internal const string Mesmerist = "3bc07235efe64033a30fca8ecb9f3dc6";
        internal const string MesmeristProgression = "c1a82b2f0570456280d5eec2189771d6";
        internal const string MesmeristProficiencies = "efea9643fea54d12b04a404614455705";
        internal const string MesmeristSpellsPerDayTable = "6a489392accd4a49b43d5ee7222bf084";
        internal const string MesmeristSpellSlotsTable = "712bba2411604456bb48bec17ba57b5c";
        internal const string MesmeristSpellbook = "51c5279f75bd45bb810ca899fd6a7c65";
        internal const string MesmeristSpellList = "8109a365b02f48768c33ceb48dfd9de6";
        internal const string ConsummateLiar = "8e9e7d3f4ba940b8ac3f33cbc17b8b01";
        internal const string ToweringEgo = "37ac11e9d800418e852572863a223f8e";
        internal const string MentalPotency = "abf5de27d3114530aa87d1ade07d52b5";
        internal const string MasterfulTricks = "61c6ea2e943a4fe7a1147124d69483d5";
        internal const string PiercingGaze = "662519a1f8254afa9bfa3ebeda115f0d";

        internal const string TouchTreatment = "f6ba9b447fad4af78819f2fab786d9f1";
        internal const string TouchTreatmentSelfAbility = "94bdbe73eb07499bb158893b0d7aef05";
        internal const string TouchTreatmentOtherAbility = "bbd867473d8c491385082a8e8bbe40cb";
        internal const string TouchTreatmentResource = "7d30979bc9e74833ac6f3e4c3981c67a";
        internal const string TouchTreatmentResourceFeat = "ce3ae52507044ed197f26511b90a989c";
        internal const string TouchTreatmentMinor = "7cdad460cb9544d59588a19b1c1dc0c7";
        internal const string TouchTreatmentModerate = "d263573fb55b4cd6a66c286b08371c3e";
        internal const string TouchTreatmentGreater = "0d229837f32b481e833d1e08dbd4fda0";
        internal const string TouchTreatmentBreak = "94ef70a3697a4515ab0cf908d4712adf";

        internal const string HypnoticStare = "59ae9ae1eddb4493939a3b9250b0d0cd";
        internal const string HypnoticStareAbility = "6d947d9cda924612ae48c73b706ab000";
        internal const string HypnoticStareBuff = "47332794eb3640289b9307c675b68343";


        internal const string PainfulStare = "c8ce0b5e91c14348bec839465aaea136";
        internal const string PainfulStareCooldown = "fac154513a9c4140b5274d0f0f9f16a7";
        internal const string ManifoldStarePainfulStare = "977a2ca2155f45ad877e63b1a1267c18";
        internal const string ManifoldStareBuff = "9b74742129d9436fb344070a9de6f730";

        internal const string MesmeristTrickSelection = "dd565aa716ab40f2bc62a4bc91561d94";
        internal const string MesmeristTrickResource = "ade07cafbc014b5a8f5e4890e7b95db5";
        internal const string MesmeristTrickResourceFeature = "c95d80ef5b354249a505e8a8690435cb";
        internal const string MesmeristTrickAbility = "037f6f5ef1fa4382b3ef0f42a8478bce";
        internal const string MesmeristUseTrick = "";
        internal const string InitialTrick = "5b2825a1df5943e5a12e3f87b33b0aeb";
        internal const string ManifoldTrick = "f28e499828b6455bb2d0866730a845fb";
        internal const string ManifoldTrick3 = "eff02305f7aa44308b8f6d10e2bf4863";
        internal const string ManifoldTrick4 = "abf03365b7ba41301b876d10e4bac863";
        internal const string ManifoldTrick5 = "bbf1324544ba41301b876d10e4bac863";
        internal const string ManifoldTrickVariantBuff = "3a71835aa729440fb49bd93c82079c92";
        internal const string ManifoldTrick1Buff = "ee14db0820ac41ebb643f7261ec0f534";
        internal const string ManifoldTrick2Buff = "58f2b36a776044098006e3d3a82198cd";
        internal const string ManifoldTrick3Buff = "96214f3f623b42ce9960b38e733679db";
        internal const string ManifoldTrick4Buff = "5b71488061bb4cb9b08c38d919f21f97";
        internal const string ManifoldTrick5Buff = "66eb314facb94050a46fa6cc4ed6f0c5";
        internal const string MaxTrickResource = "dd0a59f7acbf43998d4cfcb5e463f7e7";

        internal const string MesmeristTrickActiveVariants = "785ae6fbc1de4cfeb701ab9daebe3a8d";
        internal const string MesmeristTrickActiveAbility1 = "c7d6a862529341bda13a77ab220f17b6";
        internal const string MesmeristTrickActiveAbility2 = "ba4a9d93eb77435fb725abd2fac11eb2";
        internal const string MesmeristTrickActiveAbility3 = "4c85b4bfbcd243eeb86d940f22e721bd";
        internal const string MesmeristTrickActiveAbility4 = "ab6adfd8f1f1439282988599f3b8ca71";
        internal const string MesmeristTrickActiveAbility5 = "871737fd96ab445fadbf0194436b0aa8";



        internal const string BoldStareSelection = "7918dc4708e046078be61b079146ecbb";

        internal const string Disorientation = "2018b3adb88943e3a9c04ec91c720f14";
        internal const string DisorientationBuff = "ac96991b34f943748258bb99ea62d56f";
        internal const string DisorientationAbility = "286f50e6fa674f8093c8a2d90a8c394c";
        internal const string Disquiet = "8c9659f8d09d46b9a8efea84dfcf46d6";
        internal const string DisquietBuff = "5824022e07954295b8e17d912df10e8b";
        internal const string Distracted = "296d61d724914297b541e97e003a0f9b";
        internal const string DistractedBuff = "11c1c75964f945148019d347da401287";
        internal const string Infiltration = "398d55db8b194878a6c117e4dafc9040";
        internal const string InfiltrationBuff = "cf154a440aca48b5837226c9ff3df546";
        internal const string Lethality = "0e3f0be664794535a61abc99456ddfe9";
        internal const string LethalityBuff = "01717a83be7d47bd82807071de46b71a";
        internal const string Nightmare = "b54628f200864843964ca584f8c84fac";
        internal const string NightmareBuff = "8217c88f4ae34fd990654fc6db11424a";
        internal const string PsychicInception = "885cfcb34bdd4bb08e561c390b8d756b";
        internal const string PsychicInceptionBuff = "91c8f2f30aff4986b72c5358d5701ae3";
        internal const string SappedMagic = "e1b9be852b054a2ab7db5c1d95cca367";
        internal const string SappedMagicBuff = "bf632891f03c486591f8ec3c35cc0386";
        internal const string Sluggishness = "2e0542e1d68547f1b81791ccdde0b636";
        internal const string SluggishnessBuff = "a5b9d8dc6eb84b918cf6fd8eef858d96";
        internal const string Timidity = "50a8c5c1f8624b588c993ffb6096d6d5";
        internal const string TimidityBuff = "519a60fddeca40a6b193f8982ac2aa65";
        internal const string Unaided = "f2cbfb49048947028e8d399ced707e23";
        internal const string UnaidedBuff = "8c168e80ac6d4d2b8a2d9b5d6a8d5e82";
        internal const string ManifoldStare = "ba69bca985f24b9cad637ca6f83c9efe";
        internal const string ManifoldStare2 = "eb7927420bf5449a9a23c3a800f3cf23";
        internal const string ManifoldStare3 = "ea384c5a35054fcba5b38185404b1909";
        internal const string ManifoldStare2Buff = "0bee9cbe5a6a4429a823f8c464ec69e2";
        internal const string ManifoldStare3Buff = "28241028e8a7468881a27167feced923";

        internal const string TrickVariants = "e32b6e42e9cc4d0c8c7f5665c149a259";
        internal const string TrickVariantsActivatableAbility = "5134abc90d444ad1959891a1627eaeb7";

        internal const string VoiceOfReason = "a591e4a6bf8645adac4846a6d0343ef8";
        internal const string VoiceOfReasonAbility = "b591e4a6bf8645adac4846a6d0343ef8";
        internal const string VoiceOfReasonBuff = "53dd9d34c82e40c09c065e4719e92fb7";
        internal const string VoiceOfReasonBuffEffect = "fcd0bab6a5114d6dbee0897afd96c1c7";

        internal const string VanishArrow = "a4c8850a87c14d1cb826abe29b5d7939";
        internal const string VanishArrowAbility = "b4c8850a87c14d1cb826abe29b5d7939";
        internal const string VanishArrowBuff = "bef5bdfc38e545d0b005aecdc88ebedf";
        internal const string VanishArrowBuffEffect = "b5f8fd21308e41928a9bcf8b5aa78db6";

        internal const string SpectralSmoke = "0c0ee01750d34cfba93c3b3c217ef637";
        internal const string SpectralSmokeAbility = "1c0ee01750d34cfba93c3b3c217ef637";
        internal const string SpectralSmokeBuff = "4b18b7d6e42f48b4ae8ef603ea5826bc";
        internal const string SpectralSmokeBuffEffect = "f9c636b59ed842f7981430e3ce594378";
        internal const string SpectralSmokeAreaEffect = "0440b63b2c3d411482ba2bb7a1c931e7";
        internal const string SpectralSmokeAreaEffectBuff = "e83a2d8e404f43eabf9b12be66d562f0";

        internal const string ShadowSplinter = "1866abe0f89b45dca6db466679fba1d7";
        internal const string ShadowSplinterAbility = "2866abe0f89b45dca6db466679fba1d7";
        internal const string ShadowSplinterBuff = "53047fbd6eff47c698fd2a74a53711fa";
        internal const string ShadowSplinterBuffEffect = "937d9c62c9a346daa8f65c8277259004";

        internal const string SeeThroughInvisibility = "1d3c32db68eb4c80a60a6ad6d5d39329";
        internal const string SeeThroughInvisibilityAbility = "3d3c32db68eb4c80a60a6ad6d5d39329";
        internal const string SeeThroughInvisibilityBuff = "1fc67b8210b84dad95a333eed8d4a822";
        internal const string SeeThroughInvisibilityBuffEffect = "7d9062cc9db8455cbd121a2d18fc0561";

        internal const string ReflectFear = "2eaa1b8ee9db43358171b544b4028e18";
        internal const string ReflectFearAbility = "3eaa1b8ee9db43358171b544b4028e18";
        internal const string ReflectFearBuff = "2e308ccb5d7c47a1806a14be6b836c69";
        internal const string ReflectFearBuffEffect = "34d9d4f6811342dabe7fa01eb6abca9b";

        internal const string PsychosomaticSurge = "0ae725880cfd495b855244ef039c04f0";
        internal const string PsychosomaticSurgeAbility = "1ae725880cfd495b855244ef039c04f0";
        internal const string PsychosomaticSurgeBuff = "4f2163374d784d54b0ed709e917c35a0";
        internal const string PsychosomaticSurgeBuffEffect = "c892889d6beb416498e578c1411e3a38";

        internal const string MesmericPantomime = "a4b0a384e87a426db463d88e000af9e4";
        internal const string MesmericPantomimeAbility = "b4b0a384e87a426db463d88e000af9e4";
        internal const string MesmericPantomimeBuff = "90354699dd4946cb932ea9c95c19bdaa";
        internal const string MesmericPantomimeBuffEffect = "38d36bd533ac469a90dfc460badcd05f";

        internal const string MesmericMirror = "4b740880f3514433b782af90e948abcd";
        internal const string MesmericMirrorAbility = "3b740880f3514433b782af90e948abcd";
        internal const string MesmericMirrorBuff = "318f2f28bf414558b3fb33ec8f8ac18d";
        internal const string MesmericMirrorBuffEffect = "37db0012f866408e9bc5fc0f0c8388c2";

        internal const string Misdirection = "54fbaa5d048c424eb011f9ec43d4f57c";
        internal const string MisdirectionAbility = "44fbaa5d048c424eb011f9ec43d4f57c";
        internal const string MisdirectionBuff = "b6521c7bffc749ffa32500259e1ce76c";
        internal const string MisdirectionBuffEffect = "6621f4ea56584905a48a3f7f5553c5ac";
        internal const string MisdirectionFeintFeat = "db37465564b64f329fa72e7df2fd4ae3";

        internal const string MeekFacade = "64d24e857d2c4a35baecab50c747ffac";
        internal const string MeekFacadeAbility = "72d24e857d2c4a35baecab50c747ffac";
        internal const string MeekFacadeBuff = "950c8b6a2b1b4ce3a869826e3c77a778";
        internal const string MeekFacadeBuffEffect = "ab0bfb3ce05f4ccc9f77ca5dab05dda4";

        internal const string LinkedReaction = "8e93ffb7495a4a8998794571aad414b5";
        internal const string LinkedReactionAbility = "9e93ffb7495a4a8998794571aad414b5";
        internal const string LinkedReactionBuff = "bf2edec5d37b44afaed42ae3e827842c";
        internal const string LinkedReactionBuffEffect = "236454f5294b45a1944dabc95750b3f0";

        internal const string LevitationBuffer = "bf801e5b8d59473e8bf09c3b3ddab321";
        internal const string LevitationBufferAbility = "cf801e5b8d59473e8bf09c3b3ddab321";
        internal const string LevitationBufferBuff = "c62ed60c31bd4c8abb96aa8bf6de0d1e";
        internal const string LevitationBufferBuffEffect = "eed47d781014457a9c0f4868537380a0";

        internal const string FreeInBody = "2008109ff09c4f8aa94ac06a56e0c74c";
        internal const string FreeInBodyAbility = "e41bebb834cf4552a972f9c818d746d0";
        internal const string FreeInBodyBuff = "806813a3b00343bb9e5da9136c58600c";
        internal const string FreeInBodyBuffEffect = "97f09ed19a6b4b4882182e032582acbd";

        internal const string FleetInShadows = "7f20d2ed11b8490ea51400f96f9a960a";
        internal const string FleetInShadowsAbility = "8f20d2ed11b8490ea51400f96f9a960a";
        internal const string FleetInShadowsBuff = "3e31923e3f904fea9e4ed640ca355d66";
        internal const string FleetInShadowsBuffEffect = "d8a8963388d9472a90b2d31adb6a0920";

        internal const string FearsomeGuise = "866baac0fe4440ad9d999a3b50fe05a8";
        internal const string FearsomeGuiseAbility = "5d31eeca997543f9bfe20da60b201a80";
        internal const string FearsomeGuiseBuff = "0edfb75e8f714f7ab1c84562293e966f";
        internal const string FearsomeGuiseBuffEffect = "fdbac1b5d0774e78a203546993b687d8";
        internal const string FearsomeGuiseToggleEffect = "e4c2e40cab4c4414bb1aa9cc185ff646";

        internal const string FalseFlanker = "992ed94823974cd283a03755972bea3b";
        internal const string FalseFlankerAbility = "ea20972bcc074956a8bfe428a7b0afc5";
        internal const string FalseFlankerBuff = "7c8ecd8119f34aeb8635b309386ce4c7";
        internal const string FalseFlankerBuffEffect = "f32c16a5ad3e48a9a78e84a70735e659";

        internal const string CursedSanction = "d721d95f65c8416bb42813e3ac8e64b9";
        internal const string CursedSanctionAbility = "99c55a94f6c34382b1850fa7fef146f8";
        internal const string CursedSanctionBuff = "bbc7d65e24704c3c9df6086eeb89c7db";
        internal const string CursedSanctionBuffEffect = "5c0422653c0c4750a07cc1a44c114916";
        internal const string CursedSanctionDebuffEffect = "5ff5fa11668a4ca78c94c73ace42b149";

        internal const string CompelAlacrity = "0138f132f4e04acd859d8b1af605d29f";
        internal const string CompelAlacrityAbility = "b6db9e61fd3146b7995c7c5da8f25f79";
        internal const string CompelAlacrityBuff = "f6ec331c686c4bf4b67586c292223967";
        internal const string CompelAlacrityBuffEffect = "e24913f84f8e45fdaf0584be863bf781";
        internal const string CompelAlacrityDimensionDoorAbility = "b90ee3e6a9b04b5cabc6ab4206f03618";
        internal const string CompelAlacrityDimensionDoorFeat = "8e456e09d73e4a31a867b4a6371b7a64";

        internal const string AstoundingAvoidance = "f4a114d9b79540d98c62dafe10801c89";
        internal const string AstoundingAvoidanceAbility = "7ab206b8bc9246579edcb442a2c1c13d";
        internal const string AstoundingAvoidanceBuff = "15fd15056b1f46ec8ebd1d493b760fc6";
        internal const string AstoundingAvoidanceBuffEffect = "ea416aba50d346d78a6f7a341e042af5";
        internal const string AstoundingAvoidanceBuffEffectImproved = "bb2d94b964f64220b87cb199cdc7c7ed";

        internal static readonly (string guid, string displayName)[] Classes =
         new (string, string)[]
         {
             (Mesmerist, MesmeristClass.DisplayName)
         };
        #endregion
        //** Feats **//
        #region Features
        internal const string IntensePain = "a1cd3fdb625c48daa8326f02a7bdd3b4";
        internal const string IntensePainProgression = "2625b09e2bf145a5a49088d3f07c352f";
        internal const string FatiguingStare = "ebd5a296b7e14ac2b26e6f3f4005802c";
        internal const string FatiguingStareBuff = "472ecb8bf69c4fac981b72f7e3711d4c";
        internal const string FatiguingStareActivatableAbility = "437717b029c9409e82e5fc4246eda382";
        internal const string ExcoriatingStare = "c70863265fef4c769872ea51a293294e";
        internal const string ExcoriatingStareBuff = "7af5348debda49189407eb4a090a5fc0";
        internal const string ExcoriatingStareActivatableAbility = "924e9676a4254aa48628602c817d19d1";
        internal const string BleedingStare = "1664b8b643314272892bf79f80518b5f";
        internal const string BleedingStareBuff = "d17d603df301414081a99cce891a75e0";
        internal const string BleedingStareBuffEffect = "f45fdb73388147e8b61fcbe1d4865088";
        internal const string BleedingStareActivatableAbility = "4a74026772f2468ca45a381235e2b7bc";
        internal const string DemoralizingStare = "33c6aa640e59415eaedde41d22191742";
        internal const string DemoralizingStareBuff = "cc8535e244164db48dc092cd11eb4f4c";
        internal const string DemoralizingStareActivatableAbility = "0d45ad1a9e474312a743ffcbf75a6286";
        internal const string CompoundedPain = "87982324bf284162a078adf0ed8f5cb1";

        internal static readonly (string guid, string displayName)[] Features =
          new (string, string)[]
          {
              //(ImprovedSpellSharing, Feats.ShareSpells.DisplayName)
          };
        #endregion

        #region Spells
        internal const string MesmeristSleepAbility = "9aea15561baa47c998f2861599d1a1f5";
        internal const string MesmeristHypnotismAbility = "bb9b0ec7099749d4b13523ae27b320ab";
        internal const string MesmeristColorSprayAbility = "8270afa6e18e42088a7ea4bb9dc0bf1a";
        internal const string MesmeristRainbowPatternAbility = "3b23f4b677f641ea903e1254dcc2d414";

        internal static readonly (string guid, string displayName)[] Spells =
          new (string, string)[]
          {
              //(StrongJawSpell, StrongJaw.DisplayName),
              //(AtavismSpell, Atavism.DisplayName),
          };
        #endregion

        #region Homebrew
        internal static readonly (string guid, string displayName)[] Homebrews =
          new (string, string)[]
          {
              //(MythicAnimalFocus, Homebrew.MythicAnimalFocus.DisplayName),
          };
        #endregion

    }
}

