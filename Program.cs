using NetTopologySuite.Geometries;

var geoFactory = new NetTopologySuite.Geometries.Prepared.PreparedGeometryFactory();
var preparedGeometry = geoFactory.Create(
        Geometry.DefaultFactory.CreatePolygon(new[] {
            new Coordinate(0, 0), new Coordinate(0,2), new Coordinate(2,2), new Coordinate(2,0), new Coordinate(0,0)
        })
); ;

List<Coordinate> ccs = new List<Coordinate>();
ccs.Add(new Coordinate(3, 3));
ccs.Add(new Coordinate(2, 2));
ccs.Add(new Coordinate(1, 1));

for (int i = 0; i < ccs.Count; i++)
{
    Coordinate cc = ccs[i];

    var isTouched = preparedGeometry.Touches(Geometry.DefaultFactory.CreatePoint(cc));          // Point Touches Polygon Boundary
    var isContained = preparedGeometry.Contains(Geometry.DefaultFactory.CreatePoint(cc));       // Point Completely Locates Inside Polygon Boundary (Point is "Within" Polygon, but Polygon is not within point)
    var isIntersected = preparedGeometry.Intersects(Geometry.DefaultFactory.CreatePoint(cc));   // Touch + Contain

    string isTouched_msg = $"Touches: {isTouched}";
    string isContained_msg = $"Contains: {isContained}";
    string isIntersected_msg = $"Intersects: {isIntersected}";

    Console.WriteLine(cc.CoordinateValue.ToString());
    Console.WriteLine(isTouched_msg);
    Console.WriteLine(isContained_msg);
    Console.WriteLine(isIntersected_msg);
    Console.WriteLine("");
}