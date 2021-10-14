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

**Circuit** - A trail that contains at least one edge and starts and ends at the same vertex.

> All circuits are closed walks.
>
> A **simple circuit** is one with no repeating vertices.

