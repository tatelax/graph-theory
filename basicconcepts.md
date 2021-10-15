#  Basic Concepts

**Conjecture** - A statement that is being proposed to be true

**Theorem** - A statement that can be shown to be true

**Axiom (or postulate)** - Statements that we assume to be true

**Lemma** - A less important theorem that is helpful in the proof of theorems

**Corollary** - A theorem that can be established directly from a theorem that has been proven

**Parity** - Whether or not a number is odd or even

**Degree** - The number of edges with that vertex as an end-point

**|V|** - Total # of vertices

**|E|** - Total # of edges

**Size of Graph** - |E|

***Sum of Degrees of Vertices Theorem*** *(Handshaking Theorem)* - Total degree of a particular graph = 2|E|

> The total degree of a graph is even

> In any graph, there are an even number of vertices of odd degree

**Adjacent** - Two edges that are connected by an edge || Two edges that share a vertex

> A loop causes a vertex to be *adjacent* to itself

**Incident** - An edge is incident on its end points

**Adjacency Matrix** - A matrix which represents how many times 2 given **vertices** are adjacent (connected). 

>  Read left to right.
>
> Typically labeled as A, the image does not show this.

![Adjacency Matrix](img/adjacencymatrix.jpg)

**Incidence Matrix** - A matrix which represents how many times a given **edge** is connected to a vertex. 

> Read top to bottom left to right.
>
> For loops you put 2.
>
> Typically labeled as M, the picture is not correct.
>
> If you read a column, there will only ever be 2 entries because an edge can only have 2 connected vertices.

![Incidence Matrix](img/incidencematrix.png)



**Isomorphism** - Two graphs G1 and G2 are isomorphic they have the same number of vertices and edges and if there exists a matching between their vertices so that two vertices are connected by an edge in G1 if and only if corresponding vertices are connected by an edge in G2.

> The below 2 graphs are the same (isomorphic) despite looking different and having different names for the vertices.
>
> **⇠=** The isomorphism symbol.
>
> G1 ⇠= G2

![Isomorphism](img/isomorphism.png)

**Walk** - A walk from v to w is a finite alternating sequence of adjacent vertices and edges of G.

> This basically means the path you take to get from one vertex to another. Walking the graph.
>
> The sequence alternates between vertex, edge, vertex, edge, ...

**Length of a Walk** - Number of edges you walk in a sequence.

**Trivial Walk** - When the length of a walk is zero. (1 vertex only in the sequence)

**Open Walk** - When you start at a vertex and end at a different vertex in a sequence.

**Closed Walk** - When you start at a vertex and end at the same vertex in a sequence.

**Trail** (Type of Walk) - A trail from v to w is a walk from v to w that **does not** contain a repeated **edge**.

**Path** (Type of Walk) - A path from v to w is a trail that **does not** contain a repeated **vertex**.

**Distance** - The smallest length of a path between two vertices.

> In the graph below, the distance between a and c is 1
>
> The distance between a and b is 1
>
> The distance between a and d is 2

![Graph](graph.jpg)

**Circuit** - A trail that contains at least one edge and starts and ends at the same vertex.

> All circuits are closed walks.
>
> A **simple circuit** is one with no repeating vertices.

**Eccentricity** - Denoted ecc (v), the distance from v to a vertex farthest from v.

> ecc(a) = 2
>
> The eccentricity of a is 2 because d is the furthest vertex from a and the distance of a to d is 2.
>
> Remember, calculating distance means to use the shortest path from one vertex to another.
>
> Eccentricity is defined for a **vertex** not a graph.

![Graph](graph.jpg)

**Diameter** - Denoted diam(G), the maximum eccentricity possible of a graph.

> The diameter of the above graph would be diam(G) = 2

**Radius** - Denoted rad(G), the minimum eccentricity possible of a graph.

> The radius of the above graph would be rad(G) = 1

**Peripheral Vertex** - If ecc(v) = diam(G), then v is a peripheral vertex.

**Central Vertex** - If ecc(v) = rad(G), then v is a central vertex.

**Connectedness** - A graph is connected if and only if there is a walk between each pair of vertices.

**Component** - A disconnected set of edges from a graph.

![disconnected graph](img/disconnectedgraph.png)

**Disconnecting Set** - A set of edges whose removal disconnects G (graph).

> In the below graph, the disconnecting set would be {b, c, d} because if you removed those edges, the graph would become disconnected.

![disconnecting set](img/disconnectedset.png)

**Cut Set** - A disconnecting set such that no proper subset of that disconnecting set is disconnecting.

> In the above graph, {c, d} would be the cut set because you cannot remove any of those edges and still get a disconnecting set. For example if you just removed c or just removed d, the graph would still be connected.

**Proper Subset** - A subset of a set such that it does not contain all of the elements of a set.

**Bridge** - A cut set with 1 edge.

> g is a bridge in the below graph. In the above graph, k would be the bridge.

![bridge](img/bridge.png)

**Edge Connectivity** - Denoted as λ(G), the minimum number of edges you would have to delete to disconnect the graph.

> The edge connectivity **λ**(G) of the graph above is 1 because if you remove g the edge becomes disconnected.

**Separating Set** - A set that contains the vertices whose removal from the graph (G) disconnects G.

> Examples of separating sets from the above graph: {4}, {4, 6}. If you removed 4 or 6 vertices from the graph, it would become disconnected.

**Cut Vertex** - A vertex such that if you delete it from the graph, you have more components.

> 4 and 6 in the above graph are cut vertices because if you deleted them the number of components in graph G would increase.

**Vertex Connectivity** - The number of vertices you would need to delete to disconnect a graph G.

> The vertex connectivity in the above graph is 1 because if you removed one vertex (4 or 6) the graph would be disconnected.

**Euler Trail** - A trail that visits every edge exactly once.

> To know if a graph has an euler trail, every vertex should have an even degree except 2 of them.
>
> You start walking the path at an odd degree vertex.

**Euler Circuit** - An euler trail that visits ever edge exactly once and starts and ends at the same vertex.

**Eulerian Graph** - A connected graph G is Eulerian if and only if the degree of each vertex of G is even.
