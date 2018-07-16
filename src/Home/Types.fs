module Home.Types

type NodeId = string
type NodeLabel = string

type Node = {
    name: string
    note: string
    fold: bool
    children: NodeId list
}

type Model = {
    nodes: Map<NodeId,Node>
    focus: NodeId
}

type Msg =
    | Failure of System.Exception
