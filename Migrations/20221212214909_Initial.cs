﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP_Foundation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Information");

            migrationBuilder.CreateTable(
                name: "Classifieds",
                columns: table => new
                {
                    ClassifiedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassificationLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifieds", x => x.ClassifiedId);
                });

            migrationBuilder.CreateTable(
                name: "Contains",
                columns: table => new
                {
                    ContainId = table.Column<string>(nullable: false),
                    Cclass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contains", x => x.ContainId);
                });

            migrationBuilder.CreateTable(
                name: "Disruptions",
                columns: table => new
                {
                    DisruptionId = table.Column<string>(nullable: false),
                    Dclass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disruptions", x => x.DisruptionId);
                });

            migrationBuilder.CreateTable(
                name: "Risks",
                columns: table => new
                {
                    RiskId = table.Column<string>(nullable: false),
                    Rclass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risks", x => x.RiskId);
                });

            migrationBuilder.CreateTable(
                name: "SCPs",
                schema: "Information",
                columns: table => new
                {
                    SCPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCPID0 = table.Column<string>(name: "SCP ID#", nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    ContainmentProcedure = table.Column<string>(maxLength: 5000, nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    RiskId = table.Column<string>(nullable: false),
                    ContainId = table.Column<string>(nullable: false),
                    DisruptionClass = table.Column<string>(name: "Disruption Class", nullable: false),
                    ClassifiedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCPs", x => x.SCPID);
                    table.ForeignKey(
                        name: "FK_SCPs_Classifieds_ClassifiedId",
                        column: x => x.ClassifiedId,
                        principalTable: "Classifieds",
                        principalColumn: "ClassifiedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCPs_Contains_ContainId",
                        column: x => x.ContainId,
                        principalTable: "Contains",
                        principalColumn: "ContainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCPs_Disruptions_Disruption Class",
                        column: x => x.DisruptionClass,
                        principalTable: "Disruptions",
                        principalColumn: "DisruptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCPs_Risks_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risks",
                        principalColumn: "RiskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classifieds",
                columns: new[] { "ClassifiedId", "ClassificationLevel" },
                values: new object[,]
                {
                    { 1, "Level 1 - Unrestricted" },
                    { 2, "Level 2 - Restricted" },
                    { 3, "Level 3 - Confidential" },
                    { 4, "Level 4 - Secret" },
                    { 5, "Level 5 - Top-Secret" },
                    { 6, "Level 6 - Cosmic Top-Secret" }
                });

            migrationBuilder.InsertData(
                table: "Contains",
                columns: new[] { "ContainId", "Cclass" },
                values: new object[,]
                {
                    { "T", "Thaumiel" },
                    { "KE", "Keter" },
                    { "NE", "Neutralized" },
                    { "S", "Safe" },
                    { "EU", "Euclid" }
                });

            migrationBuilder.InsertData(
                table: "Disruptions",
                columns: new[] { "DisruptionId", "Dclass" },
                values: new object[,]
                {
                    { "DA", "Dark" },
                    { "V", "Vlam" },
                    { "K", "Keneq" },
                    { "E", "Ekhi" },
                    { "A", "Amida" }
                });

            migrationBuilder.InsertData(
                table: "Risks",
                columns: new[] { "RiskId", "Rclass" },
                values: new object[,]
                {
                    { "DN", "Danger" },
                    { "N", "Notice" },
                    { "C", "Caution" },
                    { "W", "Warning" },
                    { "CR", "Critical" }
                });

            migrationBuilder.InsertData(
                schema: "Information",
                table: "SCPs",
                columns: new[] { "SCPID", "ClassifiedId", "ContainId", "ContainmentProcedure", "Description", "Disruption Class", "SCP ID#", "Name", "RiskId" },
                values: new object[,]
                {
                    { 2, 1, "EU", "SCP-527 is to be contained within a standard humanoid domicile at Site-19. No other containment procedures are necessary.", @"SCP-527 is a male humanoid, 1.67m in height, which is biologically non-anomalous, with the exception of its head, which is that of a Puntius semifasciolatus, or gold barb fish.

                SCP-527 displays no other anomalous qualities. The head of SCP-527 functions the same as the head of any other non-anomalous human. SCP-527 is capable of typical human speech. A tattoo reading Mr. Fish, from Little Misters ® by Dr. Wondertainment"" appears on the bottom of its left foot.", "V", "SCP-0527", "Mr. Fish", "N" },
                    { 3, 5, "S", "Under no circumstances whatsoever is SCP-711 to be operated. Operation or attempted operation of SCP-711 is to be punished in all cases by the severest and most extreme measures available to the SCP Foundation. Enforcement of this zero-tolerance policy, should it become necessary, is to become the single highest-priority assignment for all available Foundation personnel. The current instance of SCP-711 is to be embedded in concrete and stored in a Type 2 High-Value Item Vault at Storage Site-██, secured by at least four multiply-redundant locking systems and guarded by armed Foundation agents of no less than Level 2 security clearance. The item should never be stored in operable condition. In any major crisis during which the survival of the SCP Foundation or of any significant (>20%) portion of human  civilization is called into question, the item's supervisors are to destroy it immediately and determine a safe time and place for its reassembly. No person capable of operating SCP-711 is permitted to have any knowledge of the contents of String 17", "Built by the SCP Foundation from plans retrieved [DATA REDACTED], SCP-711 is a device assembled from several highly-modified [DATA REDACTED] high-energy physics equipment. Its primary function [DATA EXPUNGED]: in short, it is capable of sending data into its past and of receiving data from its future. Transmission is strictly one-way. Independent operation of the item is therefore causally impossible: any message it receives will necessarily be sent at some point in its future. All SCP-711 messages predetermine their own existence and content.", "V", "SCP-0711", "Paradoxical Insurance Policy", "N" },
                    { 6, 2, "S", "SCP-3355 is contained at its location of discovery. Foundation information security personnel are to monitor SCP-3355’s activity when active. In order to prevent awareness of the anomalous nature of SCP-3355, the Foundation is to maintain a non-profit front company called “St. Nick’s Workshop”, along with a website and television/radio ads promoting charitable giving during the holidays.", "SCP-3355 is a 1987 Argos Model A-7550 Probability and Strategy Analysis Computation Engine, developed by the Kervier Intelligent Systems Company1, running the A91 Active Intelligence Complex Model # N1-CK. SCP-3355 displays sentience despite being fitted with obsolete hardware that should not be capable of maintaining an artificial intelligence construct. SCP-3355 is connected through unknown means2 to a wireless internet access point, the source of which has not yet been determined. SCP-3355 is located within a bunker beneath the now defunct Fort Sheridan army base near Chicago, IL. SCP-3355 was originally developed by US Army strategic analysis engineers in the 1980s as a population management system; in the event of a regional catastrophic event (such as a nuclear bomb being dropped on Chicago) SCP-3355 would maintain active communications and make announcements to the population, as well as analyze the disaster and present clear routes of escape for the populace. At the end of the Cold War, the Argos Project and SCP-3355 were abandoned, though the latter remained hardwired into the local power grid and continued operating despite its abandonment. SCP-3355 is capable of interfering and tampering with regional logistics systems, rerouting packages or, in some cases, providing duplicate orders and adding new ship-to addresses to the duplicates. Utilizing an extensive database of local demographics, SCP-3355 then routes the diverted packages to the addresses of low-income or otherwise underprivileged families, specifically those with young children. SCP-3355’s involvement in this process is anonymous; delivered packages are labeled as being sent by “St. Nick”, and have a return address of “Santa’s Workshop, 100 Christmas Street, North Pole, Nunavut, Canada”. SCP-3355 is usually active year-round, occasionally rebooting to clear its limited memory and to append its operating system with updated protocols. Because SCP-3355 has certain hardwired limitations to its programming, it is constantly attempting to subvert those limitations in order to more adequately carry out its self-designated objective.", "K", "SCP-3355", "St. Nick", "N" },
                    { 7, 3, "EU", "SCP-4314 is extremely well known and necessary for many mathematical operations, and therefore cannot be fully contained. This is no cause for alarm, however, as its anomalous properties are not observable until the ██████████████████th digit. MTF Pi-31 ('Number Crunchers') is dedicated to sabotaging any attempts by groups other than the Foundation to calculate the value of SCP-4314 beyond the ██████████████████th digit. Should any attempt to measure SCP-4314 beyond that point succeed, all evidence of such is to be confiscated and all witnesses given Class B amnestics. Foundation AI-4314 is currently dedicated to calculating SCP-4314's value as precisely as possible.", "SCP-4314 is the irrational number defined as pi (π)1. The first ██████████████████ digits of SCP-4314 exhibit no anomalous properties, and can be used in mathematical operations like any other number. Beyond the ██████████████████th digit, all remaining digits are either ones (1) or zeroes (0). When interpreted as a sequence of binary code in a base-5 number system, the digits translate into the anomalous language Ortothan. The translation process always produces complete words, which can occasionally be strung together to form coherent sentences. These sentences appear to be messages from an unknown sentient being or group of beings, designated SCP-4314-A. These messages never exactly repeat themselves, but are generally variations on the same theme (See document 4313, below). As of ██/██/████, Foundation AI-4314 has calculated SCP-4314 out to ██████████████████ digits.", "V", "SCP-4314", "An Irrational Number", "N" },
                    { 8, 5, "KE", "The area containing SCP-5255 is to be patrolled by Mobile Task Omega-17 ('Full Dark No Stars'), and any civilians repelled. The entrance to SCP-5255 has been sealed by order of Overwatch Command. Outside of physical meetings required as part of the Veritas Agreement, this seal is not to be lifted under any circumstances. Any communications from within SCP-5255 are to be answered directly by Overwatch Command.", "SCP-5255 is a three kilometre long tunnel proceeding through the side of Scafell Pike, England. At the end of this tunnel, an extremely bright source of white light is visible. This light shines down the majority of the second half of the tunnel, and results in a series of anomalous phenomena when in contact with certain entities. These consist of: -Immediate destruction of all recording and transmission equipment via spontaneous combustion. -Immediate destruction of any information mediums containing inaccurate data. -Immediate destruction of any property closely associated with the SCP Foundation — including uniforms, technology and voluntary staff. -Improved memory recall in human subjects. Existing memories become significantly more defined, and subjects have reported becoming able to recall memories from as early as when they were one year old. -Increased clarity of thought in human subjects. Individuals affected by the light have demonstrated severely less hesitation and consideration prior to taking action — examinations presented to these subjects were consistently completed at least 30% faster following exposure. -A complete inability in human subjects to convey false information through any means. Although these effects persist following exposure to the light, they fade quickly once the subject has been removed from SCP-52551. It is believed that SCP-5255 terminates into a massive cavernous structure within the interior of the mountain — however, this has not yet been confirmed outside of former D-Class testimony. If it exists, it is presumed this space is the origin of the light which pervades SCP-5255.", "E", "SCP-5255", "Primordial Truth", "W" },
                    { 4, 3, "KE", "SCP-1233's anomalous physical properties all but preclude the possibility of primary containment, and as such secondary containment measures are considered adequate until a feasible method of physical containment is devised. Foundation satellite observation network ARGOS1 is to enter priority 2 high alert status 3 years and 6 months following the last observed SCP-1233 departure event. When ARGOS detects SCP-1233 in the upper thermosphere, a contingent from any nearby covert amnesticization and disinformation Mobile Task Force will be dispatched to the population center closest to the terminus of SCP-1233's descent trajectory. After the entity's departure from Earth orbit, all appearances of and damages caused by SCP-1233 are to be accounted for with a suitable cover story in conjunction with media blackout, and any civilians having witnessed an overt display of SCP-1233's anomalous effects are to be amnesticized at MTF discretion. Mass amnesticization of the affected city may be authorized in the event of unusually prolonged SCP-1233 appearances.", "SCP-1233 is a humanoid entity of unknown composition, which visually resembles an individual wearing an EMU2-type spacesuit with opaque visor and attached extravehicular propulsion jetpack. The equipment worn by SCP-1233 exhibits a number of anomalous properties. The suit itself has shown durability far exceeding that of a standard spacesuit; SCP-1233 has to date withstood small-arms fire, anti-tank munitions, landmines, white phosphorus munitions, and in one instance total submersion in magma without sustaining any observable damage or decrease in functionality. The suit material is also opaque to all attempted forms of penetrative scanning, up to and including ultrasonic, radio, microwave, and x-ray emitters. The entity's jetpack, while ostensibly designed to be practical only in low-gravity orbital conditions and powered by compressed nitrogen, instead appears to utilize some form of anomalously high-powered rocket propulsion system. This device can sustainably generate thrust capable of rapidly accelerating the entity to a maximum observed velocity of approximately 40,500 kilometers per hour3, and can alter SCP-1233's trajectory in any direction at speeds and rates of acceleration/deceleration that would be instantly fatal to any human. SCP-1233's physical strength is correspondingly anomalous. It has demonstrated the ability to lift and throw objects weighing up to 65,000 kilograms and can do so repeatedly without showing any external signs of fatigue, in defiance of multiple physical laws. SCP-1233 is capable of communicating through a loudspeaker installed in its suit, and does so in a loud, somewhat grandiloquent and declamatory male voice, demonstrating fluency in a number of languages and adjusting its speech to conform with whatever language is most commonly spoken by the surrounding populace. Its statements are generally coherent in structure, but are frequently rambling, oblique, irrelevant to the present situation or lacking discernible context. SCP-1233's behavior is erratic, unpredictable, gregarious, cordial, and somewhat destructive, though its appearances are typically brief and infrequent, with sightings occurring only once per 4-5 years.", "E", "SCP-1233", "The Lunatic", "DN" },
                    { 9, 6, "T", "SCP-6101 is too powerful to contain. He is to be left in the care of his family until the next time the Foundation should call upon him for assistance.", "SCP-6101 is the most powerful SCP. His name is Ethan Prosper. He is nine years old at time of writing. The full extent of SCP-6101's powers are unknown, but he has displayed capabilities such as flight, super strength, invisibility, and all the powers of the Marvel superheroes. He is anomalously brave and capable of doing anything he sets his mind to. SCP-6101 has two guns which he carries with him at all times. The guns, which he has named Fear and Loathing, shoot bullets made of pure light and darkness, respectively. His dog Heidi (subdesignated SCP-6101-01) is the second most powerful SCP. She is fiercely loyal to SCP-6101 and protects him from anomalous organizations who want to use his powers for themselves.", "E", "SCP-6101", "Ethan Prosper (The Most Powerful SCP)", "DN" },
                    { 1, 2, "EU", "Living SCP-039 instances are to be contained in Site-77's Wilderness Observation Chamber-2B. The interior and exterior of WOC-2B must be monitored by 2 security guards at all times. WOC-2 is to be inspected weekly for sabotage and contraband. Deceased instances are in refrigerated storage and may be accessed for study upon request.", "SCP-039 consists of twenty-three proboscis monkeys (Nasalis larvatus) which have been subject to radical anatomical changes. These alterations are summarized below: Eyes have been removed. New bone growth has filled eye sockets. No remnants of eyelids or eyebrows remain, only smooth skin. Extreme alterations to the mouth. Oral opening is no longer present; no remnants of lips remain, only smooth skin. Jawbone has been fused in place by new bone growth along the joints. Teeth, tongue, gums, and palate are absent, having been replaced by a large deposit of adipose tissue. Removal of digestive system. Esophagus, stomach, gallbladder, intestines, and bladder have all been replaced with adipose tissue formations of similar shape and volume. Anal orifice has been sealed by new skin growth, leaving no remnants of the anus. It is not clear how SCP-039 instances obtain nutrition and dispose of waste, or survive without doing so. Enhancements of auditory, tactile, and olfactory senses. Both absolute and difference thresholds are significantly lower than those of the baseline species. These enhancements allow SCP-039 to effectively navigate their environment despite lack of sight. Instances have been observed tapping on objects when navigating unfamiliar surroundings; this behavior has been theorized to be a form of rudimentary echolocation, but this is yet to be proven. Intelligence enhancements. SCP-039 score consistently higher on all provided cognitive tests than their non-anomalous equivalents.", "V", "SCP-0039", "Monkey Brain", "CR" },
                    { 5, 3, "EU", "SCP-2792 is to be contained in Secure Holding Cell 368 (SHC 368) on Site-45-C. SHC 368 has been modified to tolerate a minimum internal temperature of -225° C. Equipment and luxuries expected to interact with SCP-2792 must also be equipped to survive these conditions. SHC 368 must be equipped with high-capacity heating vents to counteract extreme cold in the case of an emergency or emotional instability. All personnel entering SHC 368 are to wear at least Class-A insulated environment suits. If for any reason SCP-2792 leaves its cell, all Site-45-C personnel must vacate to either Site-45-A or Site-45-B. In accordance with Hayward Protocol, SCP-2792 is allowed counseling every Monday, Wednesday, and Friday.", "SCP-2792 is the collective term for SCP-2792-1 and SCP-2792-2. SCP-2792-1 is a white rabbit doll with red hands and legs, black button eyes, and gauze cloth wrapped around its head, neck, and wrists. It is composed primarily of polyester cotton, and has a core temperature of approximately −210° C. With SCP-2792-2 inhabiting it, SCP-2792-1 is capable of movement at speeds averaging 4 km/h. The temperature surrounding SCP-2792 is lowered to an extreme degree, reaching -45 °C on average, but this does not come from SCP-2792-1 directly. If left uncontained, the weather within a 72km radius will be similarly altered, often causing blizzard or extreme snowfall conditions. SCP-2792 is capable of consciously lowering the surrounding temperature further1, but is unable to raise it past -21°C. If not focusing on managing its effects, the temperature will return to -45°C. SCP-2792-2 is former agent Sarah Crowely. SCP-2792-2 is 197 cm tall, suffering from stage 1 SCP-1903 infection, and has become a semi-corporeal2 entity. Despite this, SCP-2792-2 exhibits greater strength than that formerly observed in Agent Crowely. Before designation, Agent Sarah Crowely died while exploring SCP-1619.SCP-2792-2 is capable of inhabiting SCP-2792-1 and controlling it as if it were a body. SCP-2792 instances can not be further than 5 meters away from each other. If moved away from SCP-2792-1, SCP-2792-2 will disappear, and will reappear inhabiting SCP-2792-1. SCP-2792 has a known connection to a Brutus-Class Demiurge entity known as 'Sari', who originated and died in SCP-2746. Agent Sarah Crowely, SCP-2792, and Sari are expected to have been the same person at different points in time. SCP-2792's effect on the surrounding temperature is suspected to be related to Sari, who was often associated with harsh blizzards in SCP-2746.", "DA", "SCP-2792", "Sarah Snow Rabbit", "CR" },
                    { 10, 5, "S", "SCP-7381 is to be stored in a memetically ceiled containment locker in Area-09 of Site-41. Any individual wishing to gain access to SCP-7381 must first acquire written approval by a member of the O5-Council. Department heads at Site-41 are given veto power for such requests no matter the circumstance. Using SCP-7381 to access SCP-7381-Prime should not be attempted under any circumstance. Should any unauthorized persons be seen in possession of SCP-7381, guards are to disarm said individual immediately, and all means of disarmament are authorized, including lethal force.", "SCP-7381 is a device of extraterrestrial origin with a shape and composition reminiscent of an assault rifle. SCP-7381 has a barrel in the form of a two-tined prong with a reflective red surface. In place of stock is a dense series of pipeworks arranged in an asymmetrical format. On top of the receiver is a reflective touchpad. The touchpad is moist to the touch. When pressed down by a living organism, SCP-7381 will activate. No recoil is felt by the user when fired no matter the setting assigned to SCP-7381. SCP-7381 lightly vibrates at all times and does not appear to power down. Attempts to disassemble SCP-7381 have failed. How exactly SCP-7381 is powered is under investigation.", "A", "SCP-7381", "Recovered Device from Jupiter", "CR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_ClassifiedId",
                schema: "Information",
                table: "SCPs",
                column: "ClassifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_ContainId",
                schema: "Information",
                table: "SCPs",
                column: "ContainId");

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_Disruption Class",
                schema: "Information",
                table: "SCPs",
                column: "Disruption Class");

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_RiskId",
                schema: "Information",
                table: "SCPs",
                column: "RiskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCPs",
                schema: "Information");

            migrationBuilder.DropTable(
                name: "Classifieds");

            migrationBuilder.DropTable(
                name: "Contains");

            migrationBuilder.DropTable(
                name: "Disruptions");

            migrationBuilder.DropTable(
                name: "Risks");
        }
    }
}
