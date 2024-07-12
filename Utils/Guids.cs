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
        internal const string Mesmerist = "3bc07235-efe6-4033-a30f-ca8ecb9f3dc6";
        internal const string MesmeristProgression = "c1a82b2f-0570-4562-80d5-eec2189771d6";
        internal const string MesmeristProficiencies = "efea9643-fea5-4d12-b04a-404614455705";
        internal const string MesmeristSpellsPerDayTable = "6a489392-accd-4a49-b43d-5ee7222bf084";
        internal const string MesmeristSpellSlotsTable = "712bba24-1160-4456-bb48-bec17ba57b5c";
        internal const string MesmeristSpellbook = "51c5279f-75bd-45bb-810c-a899fd6a7c65";
        internal const string MesmeristSpellList = "8109a365-b02f-4876-8c33-ceb48dfd9de6";
        internal const string ConsummateLiar = "8e9e7d3f-4ba9-40b8-ac3f-33cbc17b8b01";
        internal const string ToweringEgo = "37ac11e9-d800-418e-8525-72863a223f8e";
        internal const string MentalPotency = "abf5de27-d311-4530-aa87-d1ade07d52b5";
        internal const string MentalPotencyUnitProperty = "61c6ea2e-943a-4fe7-a114-7124d69483d5";

        internal const string TouchTreatment = "f6ba9b44-7fad-4af7-8819-f2fab786d9f1";
        internal const string TouchTreatmentSelfAbility = "94bdbe73-eb07-499b-b158-893b0d7aef05";
        internal const string TouchTreatmentOtherAbility = "bbd86747-3d8c-4913-8508-2a8e8bbe40cb";
        internal const string TouchTreatmentResource = "7d30979b-c9e7-4833-ac6f-3e4c3981c67a";
        internal const string TouchTreatmentResourceFeat = "ce3ae525-0704-4ed1-97f2-6511b90a989c";
        internal const string TouchTreatmentMinor = "7cdad460-cb95-44d5-9588-a19b1c1dc0c7";
        internal const string TouchTreatmentModerate = "d263573f-b55b-4cd6-a66c-286b08371c3e";
        internal const string TouchTreatmentGreater = "0d229837-f32b-481e-833d-1e08dbd4fda0";
        internal const string TouchTreatmentBreak = "94ef70a3-697a-4515-ab0c-f908d4712adf";

        internal const string HypnoticStare = "59ae9ae1-eddb-4493-939a-3b9250b0d0cd";
        internal const string HypnoticStareAbility = "6d947d9c-da92-4612-ae48-c73b706ab000";
        internal const string HypnoticStareBuff = "47332794-eb36-4028-9b93-07c675b68343";


        internal const string PainfulStare = "c8ce0b5e-91c1-4348-bec8-39465aaea136";
        internal const string PainfulStareCooldown = "fac15451-3a9c-4140-b527-4d0f0f9f16a7";
        internal const string ManifoldStarePainfulStare = "977a2ca2-155f-45ad-877e-63b1a1267c18";
        internal const string ManifoldStareBuff = "9b747421-29d9-436f-b344-070a9de6f730";

        internal const string MesmeristTrickSelection = "dd565aa7-16ab-40f2-bc62-a4bc91561d94";
        internal const string MesmeristTrickResource = "ade07caf-bc01-4b5a-8f5e-4890e7b95db5";
        internal const string MesmeristTrickResourceFeature = "c95d80ef-5b35-4249-a505-e8a8690435cb";
        internal const string MesmeristTrickAbility = "037f6f5e-f1fa-4382-b3ef-0f42a8478bce";
        internal const string MesmeristUseTrick = "";
        internal const string InitialTrick = "5b2825a1-df59-43e5-a12e-3f87b33b0aeb";
        internal const string ManifoldTrick = "f28e4998-28b6-455b-b2d0-866730a845fb";
        internal const string ManifoldTrick3 = "eff02305-f7aa-4430-8b8f-6d10e2bf4863";
        internal const string ManifoldTrick4 = "abf03365-b7ba-4130-1b87-6d10e4bac863";
        internal const string ManifoldTrick5 = "bbf13245-44ba-4130-1b87-6d10e4bac863";
        internal const string ManifoldTrickVariantBuff = "3a71835a-a729-440f-b49b-d93c82079c92";
        internal const string ManifoldTrick1Buff = "ee14db08-20ac-41eb-b643-f7261ec0f534";
        internal const string ManifoldTrick2Buff = "58f2b36a-7760-4409-8006-e3d3a82198cd";
        internal const string ManifoldTrick3Buff = "96214f3f-623b-42ce-9960-b38e733679db";
        internal const string ManifoldTrick4Buff = "5b714880-61bb-4cb9-b08c-38d919f21f97";
        internal const string ManifoldTrick5Buff = "66eb314f-acb9-4050-a46f-a6cc4ed6f0c5";
        internal const string MesmeristTrickActiveVariants = "785ae6fb-c1de-4cfe-b701-ab9daebe3a8d";
        internal const string MesmeristTrickActiveAbility1 = "c7d6a862-5293-41bd-a13a-77ab220f17b6";
        internal const string MesmeristTrickActiveAbility2 = "ba4a9d93-eb77-435f-b725-abd2fac11eb2";
        internal const string MesmeristTrickActiveAbility3 = "4c85b4bf-bcd2-43ee-b86d-940f22e721bd";
        internal const string MesmeristTrickActiveAbility4 = "ab6adfd8-f1f1-4392-8298-8599f3b8ca71";
        internal const string MesmeristTrickActiveAbility5 = "871737fd-96ab-445f-adbf-0194436b0aa8";



        internal const string BoldStareSelection = "7918dc47-08e0-4607-8be6-1b079146ecbb";

        internal const string Disorientation = "2018b3ad-b889-43e3-a9c0-4ec91c720f14";
        internal const string DisorientationBuff = "ac96991b-34f9-4374-8258-bb99ea62d56f";
        internal const string DisorientationAbility = "286f50e6-fa67-4f80-93c8-a2d90a8c394c";
        internal const string Disquiet = "8c9659f8-d09d-46b9-a8ef-ea84dfcf46d6";
        internal const string DisquietBuff = "5824022e-0795-4295-b8e1-7d912df10e8b";
        internal const string Distracted = "296d61d7-2491-4297-b541-e97e003a0f9b";
        internal const string DistractedBuff = "11c1c759-64f9-4514-8019-d347da401287";
        internal const string Infiltration = "398d55db-8b19-4878-a6c1-17e4dafc9040";
        internal const string InfiltrationBuff = "cf154a44-0aca-48b5-8372-26c9ff3df546";
        internal const string Lethality = "0e3f0be6-6479-4535-a61a-bc99456ddfe9";
        internal const string LethalityBuff = "01717a83-be7d-47bd-8280-7071de46b71a";
        internal const string Nightmare = "b54628f2-0086-4843-964c-a584f8c84fac";
        internal const string NightmareBuff = "8217c88f-4ae3-4fd9-9065-4fc6db11424a";
        internal const string PsychicInception = "885cfcb3-4bdd-4bb0-8e56-1c390b8d756b";
        internal const string PsychicInceptionBuff = "91c8f2f3-0aff-4986-b72c-5358d5701ae3";
        internal const string SappedMagic = "e1b9be85-2b05-4a2a-b7db-5c1d95cca367";
        internal const string SappedMagicBuff = "bf632891-f03c-4865-91f8-ec3c35cc0386";
        internal const string Sluggishness = "2e0542e1-d685-47f1-b817-91ccdde0b636";
        internal const string SluggishnessBuff = "a5b9d8dc-6eb8-4b91-8cf6-fd8eef858d96";
        internal const string Timidity = "50a8c5c1-f862-4b58-8c99-3ffb6096d6d5";
        internal const string TimidityBuff = "519a60fd-deca-40a6-b193-f8982ac2aa65";
        internal const string Unaided = "f2cbfb49-0489-4702-8e8d-399ced707e23";
        internal const string UnaidedBuff = "8c168e80-ac6d-4d2b-8a2d-9b5d6a8d5e82";
        internal const string ManifoldStare = "ba69bca9-85f2-4b9c-ad63-7ca6f83c9efe";
        internal const string ManifoldStare2 = "eb792742-0bf5-449a-9a23-c3a800f3cf23";
        internal const string ManifoldStare3 = "ea384c5a-3505-4fcb-a5b3-8185404b1909";
        internal const string ManifoldStare2Buff = "0bee9cbe-5a6a-4429-a823-f8c464ec69e2";
        internal const string ManifoldStare3Buff = "28241028-e8a7-4688-81a2-7167feced923";

        internal const string TrickVariants = "e32b6e42-e9cc-4d0c-8c7f-5665c149a259";
        internal const string TrickVariantsActivatableAbility = "5134abc9-0d44-4ad1-9598-91a1627eaeb7";

        internal const string VoiceOfReason = "a591e4a6-bf86-45ad-ac48-46a6d0343ef8";
        internal const string VoiceOfReasonAbility = "b591e4a6-bf86-45ad-ac48-46a6d0343ef8";
        internal const string VoiceOfReasonBuff = "53dd9d34-c82e-40c0-9c06-5e4719e92fb7";
        internal const string VoiceOfReasonBuffEffect = "fcd0bab6-a511-4d6d-bee0-897afd96c1c7";

        internal const string VanishArrow = "a4c8850a-87c1-4d1c-b826-abe29b5d7939";
        internal const string VanishArrowAbility = "b4c8850a-87c1-4d1c-b826-abe29b5d7939";
        internal const string VanishArrowBuff = "bef5bdfc-38e5-45d0-b005-aecdc88ebedf";
        internal const string VanishArrowBuffEffect = "b5f8fd21-308e-4192-8a9b-cf8b5aa78db6";

        internal const string SpectralSmoke = "0c0ee017-50d3-4cfb-a93c-3b3c217ef637";
        internal const string SpectralSmokeAbility = "1c0ee017-50d3-4cfb-a93c-3b3c217ef637";
        internal const string SpectralSmokeBuff = "4b18b7d6-e42f-48b4-ae8e-f603ea5826bc";
        internal const string SpectralSmokeBuffEffect = "f9c636b5-9ed8-42f7-9814-30e3ce594378";
        internal const string SpectralSmokeAreaEffect = "0440b63b-2c3d-4114-82ba-2bb7a1c931e7";
        internal const string SpectralSmokeAreaEffectBuff = "e83a2d8e-404f-43ea-bf9b-12be66d562f0";

        internal const string ShadowSplinter = "1866abe0-f89b-45dc-a6db-466679fba1d7";
        internal const string ShadowSplinterAbility = "2866abe0-f89b-45dc-a6db-466679fba1d7";
        internal const string ShadowSplinterBuff = "53047fbd-6eff-47c6-98fd-2a74a53711fa";
        internal const string ShadowSplinterBuffEffect = "937d9c62-c9a3-46da-a8f6-5c8277259004";

        internal const string SeeThroughInvisibility = "1d3c32db-68eb-4c80-a60a-6ad6d5d39329";
        internal const string SeeThroughInvisibilityAbility = "3d3c32db-68eb-4c80-a60a-6ad6d5d39329";
        internal const string SeeThroughInvisibilityBuff = "1fc67b82-10b8-4dad-95a3-33eed8d4a822";
        internal const string SeeThroughInvisibilityBuffEffect = "7d9062cc-9db8-455c-bd12-1a2d18fc0561";

        internal const string ReflectFear = "2eaa1b8e-e9db-4335-8171-b544b4028e18";
        internal const string ReflectFearAbility = "3eaa1b8e-e9db-4335-8171-b544b4028e18";
        internal const string ReflectFearBuff = "2e308ccb-5d7c-47a1-806a-14be6b836c69";
        internal const string ReflectFearBuffEffect = "34d9d4f6-8113-42da-be7f-a01eb6abca9b";

        internal const string PsychosomaticSurge = "0ae72588-0cfd-495b-8552-44ef039c04f0";
        internal const string PsychosomaticSurgeAbility = "1ae72588-0cfd-495b-8552-44ef039c04f0";
        internal const string PsychosomaticSurgeBuff = "4f216337-4d78-4d54-b0ed-709e917c35a0";
        internal const string PsychosomaticSurgeBuffEffect = "c892889d-6beb-4164-98e5-78c1411e3a38";

        internal const string MesmericPantomime = "a4b0a384-e87a-426d-b463-d88e000af9e4";
        internal const string MesmericPantomimeAbility = "b4b0a384-e87a-426d-b463-d88e000af9e4";
        internal const string MesmericPantomimeBuff = "90354699-dd49-46cb-932e-a9c95c19bdaa";
        internal const string MesmericPantomimeBuffEffect = "38d36bd5-33ac-469a-90df-c460badcd05f";

        internal const string MesmericMirror = "4b740880-f351-4433-b782-af90e948abcd";
        internal const string MesmericMirrorAbility = "3b740880-f351-4433-b782-af90e948abcd";
        internal const string MesmericMirrorBuff = "318f2f28-bf41-4558-b3fb-33ec8f8ac18d";
        internal const string MesmericMirrorBuffEffect = "37db0012-f866-408e-9bc5-fc0f0c8388c2";

        internal const string Misdirection = "54fbaa5d-048c-424e-b011-f9ec43d4f57c";
        internal const string MisdirectionAbility = "44fbaa5d-048c-424e-b011-f9ec43d4f57c";
        internal const string MisdirectionBuff = "b6521c7b-ffc7-49ff-a325-00259e1ce76c";
        internal const string MisdirectionBuffEffect = "6621f4ea-5658-4905-a48a-3f7f5553c5ac";

        internal const string MeekFacade = "64d24e85-7d2c-4a35-baec-ab50c747ffac";
        internal const string MeekFacadeAbility = "72d24e85-7d2c-4a35-baec-ab50c747ffac";
        internal const string MeekFacadeBuff = "950c8b6a-2b1b-4ce3-a869-826e3c77a778";
        internal const string MeekFacadeBuffEffect = "ab0bfb3c-e05f-4ccc-9f77-ca5dab05dda4";

        internal const string LinkedReaction = "8e93ffb7-495a-4a89-9879-4571aad414b5";
        internal const string LinkedReactionAbility = "9e93ffb7-495a-4a89-9879-4571aad414b5";
        internal const string LinkedReactionBuff = "bf2edec5-d37b-44af-aed4-2ae3e827842c";
        internal const string LinkedReactionBuffEffect = "236454f5-294b-45a1-944d-abc95750b3f0";

        internal const string LevitationBuffer = "bf801e5b-8d59-473e-8bf0-9c3b3ddab321";
        internal const string LevitationBufferAbility = "cf801e5b-8d59-473e-8bf0-9c3b3ddab321";
        internal const string LevitationBufferBuff = "c62ed60c-31bd-4c8a-bb96-aa8bf6de0d1e";
        internal const string LevitationBufferBuffEffect = "eed47d78-1014-457a-9c0f-4868537380a0";

        internal const string FleetInShadows = "7f20d2ed-11b8-490e-a514-00f96f9a960a";
        internal const string FleetInShadowsAbility = "8f20d2ed-11b8-490e-a514-00f96f9a960a";
        internal const string FleetInShadowsBuff = "3e31923e-3f90-4fea-9e4e-d640ca355d66";
        internal const string FleetInShadowsBuffEffect = "d8a89633-88d9-472a-90b2-d31adb6a0920";

        internal const string FearsomeGuise = "866baac0-fe44-40ad-9d99-9a3b50fe05a8";
        internal const string FearsomeGuiseAbility = "5d31eeca-9975-43f9-bfe2-0da60b201a80";
        internal const string FearsomeGuiseBuff = "0edfb75e-8f71-4f7a-b1c8-4562293e966f";
        internal const string FearsomeGuiseBuffEffect = "fdbac1b5-d077-4e78-a203-546993b687d8";

        internal const string FalseFlanker = "992ed948-2397-4cd2-83a0-3755972bea3b";
        internal const string FalseFlankerAbility = "ea20972b-cc07-4956-a8bf-e428a7b0afc5";
        internal const string FalseFlankerBuff = "7c8ecd81-19f3-4aeb-8635-b309386ce4c7";
        internal const string FalseFlankerBuffEffect = "f32c16a5-ad3e-48a9-a78e-84a70735e659";

        internal const string CompelAlacrity = "0138f132-f4e0-4acd-859d-8b1af605d29f";
        internal const string CompelAlacrityAbility = "b6db9e61-fd31-46b7-995c-7c5da8f25f79";
        internal const string CompelAlacrityBuff = "f6ec331c-686c-4bf4-b675-86c292223967";
        internal const string CompelAlacrityBuffEffect = "e24913f8-4f8e-45fd-af05-84be863bf781";
        internal const string CompelAlacrityDimensionDoorAbility = "b90ee3e6-a9b0-4b5c-abc6-ab4206f03618";
        internal const string CompelAlacrityDimensionDoorFeat = "8e456e09-d73e-4a31-a867-b4a6371b7a64";

        internal const string AstoundingAvoidance = "f4a114d9-b795-40d9-8c62-dafe10801c89";
        internal const string AstoundingAvoidanceAbility = "7ab206b8-bc92-4657-9edc-b442a2c1c13d";
        internal const string AstoundingAvoidanceBuff = "15fd1505-6b1f-46ec-8ebd-1d493b760fc6";
        internal const string AstoundingAvoidanceBuffEffect = "ea416aba-50d3-46d7-8a6f-7a341e042af5";
        internal const string AstoundingAvoidanceBuffEffectImproved = "bb2d94b9-64f6-4220-b87c-b199cdc7c7ed";

        internal static readonly (string guid, string displayName)[] Classes =
         new (string, string)[]
         {
             (Mesmerist, MesmeristClass.DisplayName)
         };
        #endregion
        //** Feats **//
        #region Features
        internal const string IntensePain = "a1cd3fdb-625c-48da-a832-6f02a7bdd3b4";
        internal const string IntensePainProgression = "2625b09e-2bf1-45a5-a490-88d3f07c352f";
        internal const string FatiguingStare = "ebd5a296-b7e1-4ac2-b26e-6f3f4005802c";
        internal const string FatiguingStareBuff = "472ecb8b-f69c-4fac-981b-72f7e3711d4c";
        internal const string FatiguingStareActivatableAbility = "437717b0-29c9-409e-82e5-fc4246eda382";
        internal const string ExcoriatingStare = "c7086326-5fef-4c76-9872-ea51a293294e";
        internal const string ExcoriatingStareBuff = "7af5348d-ebda-4918-9407-eb4a090a5fc0";
        internal const string ExcoriatingStareActivatableAbility = "924e9676-a425-4aa4-8628-602c817d19d1";
        internal const string BleedingStare = "1664b8b6-4331-4272-892b-f79f80518b5f";
        internal const string BleedingStareBuff = "d17d603d-f301-4140-81a9-9cce891a75e0";
        internal const string BleedingStareBuffEffect = "f45fdb73-3881-47e8-b61f-cbe1d4865088";
        internal const string BleedingStareActivatableAbility = "4a740267-72f2-468c-a45a-381235e2b7bc";
        internal const string DemoralizingStare = "33c6aa64-0e59-415e-aedd-e41d22191742";
        internal const string DemoralizingStareBuff = "cc8535e2-4416-4db4-8dc0-92cd11eb4f4c";
        internal const string DemoralizingStareActivatableAbility = "0d45ad1a-9e47-4312-a743-ffcbf75a6286";
        internal const string CompoundedPain = "87982324-bf28-4162-a078-adf0ed8f5cb1";

        internal static readonly (string guid, string displayName)[] Features =
          new (string, string)[]
          {
              //(ImprovedSpellSharing, Feats.ShareSpells.DisplayName)
          };
        #endregion

        #region Spells
        internal const string MesmeristSleepAbility = "9aea1556-1baa-47c9-98f2-861599d1a1f5";
        internal const string MesmeristHypnotismAbility = "bb9b0ec7-0997-49d4-b135-23ae27b320ab";
        internal const string MesmeristColorSprayAbility = "8270afa6-e18e-4208-8a7e-a4bb9dc0bf1a";
        internal const string MesmeristRainbowPatternAbility = "3b23f4b6-77f6-41ea-903e-1254dcc2d414";

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

