using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatosIonosfericos.Presentacion.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    dt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fromfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evaluated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fof2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fof2_eval = table.Column<bool>(type: "bit", nullable: false),
                    muf3000f2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    muf3000f2_eval = table.Column<bool>(type: "bit", nullable: false),
                    m3000f2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    m3000f2_eval = table.Column<bool>(type: "bit", nullable: false),
                    fxi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fxi_eval = table.Column<bool>(type: "bit", nullable: false),
                    fof1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fof1_eval = table.Column<bool>(type: "bit", nullable: false),
                    ftes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ftes_eval = table.Column<bool>(type: "bit", nullable: false),
                    h_es = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    h_es_eval = table.Column<bool>(type: "bit", nullable: false),
                    aip_hmf2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_fof2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_fof1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_hmf1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_d1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_foe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_hme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_yme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_h_ve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_ewidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_deln_ve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_b0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aip_b1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tec_bottom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tec_top = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fof2_med_27_days = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.dt);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
