using SolidEdgeCommunity;
using SolidEdgeFramework;
using SolidEdgeFrameworkSupport;
using SolidEdgePart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = SolidEdgeFramework.Application;

namespace Kursach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static Application seApplication;

        [STAThread]
        static void Kurs(string name1, double val1, string name2, double val2)
        {

            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents seDocuments = null;

            SolidEdgePart.PartDocument sePartDoc = null;

            SolidEdgeFramework.Variables variables = null;
            SolidEdgeFramework.VariableList listOfVariebles = null;
            SolidEdgeFramework.VariableList listOfDimensions = null;

            SolidEdgeFramework.variable varToModify = null;
            SolidEdgeFrameworkSupport.Dimension dimToModify = null;
            SolidEdgeFramework.variable varToCreate = null;

            try
            {
                OleMessageFilter.Register();

                seApplication = SolidEdgeUtils.Connect(true);

                seDocuments = seApplication.Documents;

                if (seApplication.ActiveDocumentType != SolidEdgeFramework.DocumentTypeConstants.igPartDocument)
                {
                    return;
                }

                sePartDoc = (PartDocument)seApplication.ActiveDocument;

                variables = (Variables)sePartDoc.Variables;

                listOfVariebles = (VariableList)variables.Query(
                    pFindCriterium: "*",
                    NamedBy: SolidEdgeConstants.VariableNameBy.seVariableNameByBoth,
                    VarType: SolidEdgeConstants.VariableVarType.SeVariableVarTypeVariable
                    );

          ;

                varToModify = (variable)listOfVariebles.Item(name2);
                varToModify.Value = val2;

                listOfDimensions = (VariableList)variables.Query(
                    pFindCriterium: "*",
                    NamedBy: SolidEdgeConstants.VariableNameBy.seVariableNameByBoth,
                    VarType: SolidEdgeConstants.VariableVarType.SeVariableVarTypeDimension
                    );


                dimToModify = (Dimension)listOfDimensions.Item(name1);
                dimToModify.Value = val1;


            }
            catch (Exception e)
            {

            }
            finally
            {
                OleMessageFilter.Unregister();
            }
        }

        public static void CrNew(string name3, string val3)
        {

            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents seDocuments = null;

            SolidEdgePart.PartDocument sePartDoc = null;

            SolidEdgeFramework.Variables variables = null;
            SolidEdgeFramework.VariableList listOfVariebles = null;
            SolidEdgeFramework.VariableList listOfDimensions = null;

            SolidEdgeFramework.variable varToModify = null;
            SolidEdgeFrameworkSupport.Dimension dimToModify = null;
            SolidEdgeFramework.variable varToCreate = null;

            try
            {
                OleMessageFilter.Register();

                seApplication = SolidEdgeUtils.Connect(true);

                seDocuments = seApplication.Documents;

                if (seApplication.ActiveDocumentType != SolidEdgeFramework.DocumentTypeConstants.igPartDocument)
                {
                    return;
                }

                sePartDoc = (PartDocument)seApplication.ActiveDocument;

                variables = (Variables)sePartDoc.Variables;



                varToCreate = (variable)variables.Add(
                    pName: name3,
                    pFormula: val3
                    );
            }
            catch (Exception e)
            {

            }
            finally
            {
                OleMessageFilter.Unregister();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            double val1 = 0;
            double val2 = 0;

            string name1 = textName1.Text;
            string valStr1 = textVal1.Text;

            string name2 = textName2.Text;
            string valStr2 = textVal2.Text;

            if (!string.IsNullOrEmpty(valStr1) && !string.IsNullOrEmpty(name1))
            {
                if (!double.TryParse(valStr1, out val1))
                {
                    // Обработка ошибки ввода числа
                    // Например, вывод сообщения об ошибке пользователю
                    return;
                }
            }

            if (!string.IsNullOrEmpty(valStr2) && !string.IsNullOrEmpty(name2))
            {
                if (!double.TryParse(valStr2, out val2))
                {
                    // Обработка ошибки ввода числа
                    // Например, вывод сообщения об ошибке пользователю
                    return;
                }
            }

            
            Kurs(name1, val1, name2, val2);
        }

        private void textName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            string name3 = textName3.Text;
            string val3 = textVal3.Text;

            

            CrNew(name3, val3);


        }
    }
}
