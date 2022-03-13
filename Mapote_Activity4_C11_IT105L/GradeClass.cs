using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapote_Activity4_C11_IT105L
{
    internal class GradeClass
    {
        
        public double[] InputWeightedGrades { get { return inputWeightedGrades; } set { inputWeightedGrades = value; } }
        public double[] TotalGrades { get { return totalgrades; } set { totalgrades = value; } }
        const int Totalgrades = 2;
        private double[] inputWeightedGrades;
        private double[] totalgrades = new double[Totalgrades];

        public GradeClass(double[] WeightedGradesScores)
        {
            inputWeightedGrades = WeightedGradesScores;
            totalgrades[0] = TotalGrade(inputWeightedGrades);
            totalgrades[1] = EquivalentGrade(totalgrades[0]);
        }
        private double TotalGrade(double[] WeightedGradesScores)
        {
            double total = WeightedGradesScores[0] + WeightedGradesScores[1] + WeightedGradesScores[2] + WeightedGradesScores[3] + WeightedGradesScores[4];

            return total;
        }
        private double EquivalentGrade(double finalGrade)
        {
            double equivalentGrade;

            if (finalGrade > 96 && finalGrade <= 100)
            {
                equivalentGrade = 1.00;
            }
            else if (finalGrade >= 91.51 && finalGrade <= 96)
            {
                equivalentGrade = 1.25;
            }
            else if (finalGrade >= 87.01 && finalGrade <= 91.50)
            {
                equivalentGrade = 1.50;
            }
            else if (finalGrade >= 82.51 && finalGrade <= 87)
            {
                equivalentGrade = 1.75;
            }
            else if (finalGrade >= 78.01 && finalGrade <= 82.50)
            {
                equivalentGrade = 2.00;
            }
            else if (finalGrade >= 73.51 && finalGrade <= 78)
            {
                equivalentGrade = 2.25;
            }
            else if (finalGrade >= 69.01 && finalGrade <= 73.50)
            {
                equivalentGrade = 2.50;
            }
            else if (finalGrade >= 64.51 && finalGrade <= 69)
            {
                equivalentGrade = 2.75;
            }
            else if (finalGrade >= 60 && finalGrade <= 64.50)
            {
                equivalentGrade = 3.00;
            }
            else
            {
                equivalentGrade = 5.00;
            }

            return equivalentGrade;
        }
    }
}
