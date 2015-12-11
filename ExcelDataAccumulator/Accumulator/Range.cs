using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;

namespace Accumulator {
    [Serializable]
    public class Range 
    {
        public int minX { private set; get; }
        public int maxX { private set; get; }
        public int minY { private set; get; }
        public int maxY { private set; get; }
        public string rangeName { private set; get; }
        public bool isHeader { private set; get; }
        
        public Range(int beginValueX , int endValueX , int beginValueY , int endValueY , string name, bool isHeader = false) 
        {
            if (beginValueX > endValueX) 
            {
                throw new Exception("Begin value must be big end value (" + beginValueX.ToString() + " and " + endValueX + ")");
            }
            if (beginValueY > endValueY) {
                throw new Exception("Begin value must be big end value (" + beginValueY .ToString() + " and " + endValueY + ")");
            }
            this.minX = beginValueX;
            this .maxX = endValueX;
            this .minY = beginValueY;
            this .maxY = endValueY;
            this .rangeName = name;
            this .isHeader = isHeader;
        }

        public bool intersectionRange(Range range) 
        {            
            int[] projectionAbcissa1 = { this.minX, this.minX + (this.maxX - this.minX + 1)};
            int[] projectionAbcissa2 = { range .minX , range .minX + (range .maxX - range .minX + 1) };
            int[] projectionOrdinate1 = { this .minY , this .minY + (this .maxY - this .minY + 1) };
            int[] projectionOrdinate2 = { range .minY , range .minY + (range .maxY - range .minY + 1) };
            int abcsissaCross = 0;
            int ordinateCross = 0;

            if (belongsPointToSegment((double)projectionAbcissa2[0] , (double)projectionAbcissa2[1] , (double)projectionAbcissa1[0]))
            {
                abcsissaCross++;
            }

            if(belongsPointToSegment((double)projectionAbcissa2[0] , (double)projectionAbcissa2[1] , (double)projectionAbcissa1[1]))
            {
                abcsissaCross++;
            }

            if (belongsPointToSegment((double)projectionAbcissa1[0] , (double)projectionAbcissa1[1] , (double)projectionAbcissa2[0]))
            {
                abcsissaCross++;
            }

            if (belongsPointToSegment((double)projectionAbcissa1[0] , (double)projectionAbcissa1[1] , (double)projectionAbcissa2[1]))
            {
                abcsissaCross++;
            }

            if (belongsPointToSegment((double)projectionOrdinate2[0] , (double)projectionOrdinate2[1] , (double)projectionOrdinate1[0]))
            {
                ordinateCross++;
            }

            if (belongsPointToSegment((double)projectionOrdinate2[0] , (double)projectionOrdinate2[1] , (double)projectionOrdinate1[1]))
            {
                ordinateCross++;
            }

            if (belongsPointToSegment((double)projectionOrdinate1[0] , (double)projectionOrdinate1[1] , (double)projectionOrdinate2[0]))
            {
                ordinateCross++;
            }
            if(belongsPointToSegment((double)projectionOrdinate1[0] , (double)projectionOrdinate1[1] , (double)projectionOrdinate2[1]))
            {
                ordinateCross++;
            }

            if (abcsissaCross > 0 && ordinateCross > 0)
            {
                if(!haveOnlyOnePointCross(projectionAbcissa1, projectionAbcissa2)
                    && !haveOnlyOnePointCross(projectionOrdinate1, projectionOrdinate2))
                {
                    return true;
                }
            }

            return false;
        }

        private bool haveOnlyOnePointCross(int[] segment1 , int[] segment2)
        {
            if (segment1[0] == segment2[1] || segment2[0] == segment1[1])
            {
                return true;
            }                       
            return false;
        }

        private bool belongsPointToSegment(double x1 , double x2 , double x)
        {
            double p = (x - x2)/(x1 - x2);
            return (p >= 0.0 && p <= 1.0);
        }
    }
}
