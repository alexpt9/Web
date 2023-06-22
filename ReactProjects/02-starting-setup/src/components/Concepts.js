import ConceptItem from "./ConceptItem";

const Concepts = (props) => {
  return (
    <ul id="concepts">
      <ConceptItem concept={props.concepts[0]} />
      <ConceptItem concept={props.concepts[1]} />
      <ConceptItem concept={props.concepts[2]} />
    </ul>
  );
};

export default Concepts;
