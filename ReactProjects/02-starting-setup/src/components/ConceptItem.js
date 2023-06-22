const ConceptItem = (props) => {
  const title = props.concept.title;
  const image = props.concept.image;
  const desc = props.concept.description;

  return (
    <li className="concept">
      <img src={image} alt={title} />
      <h2>{title}</h2>
      <p>{desc}</p>
    </li>
  );
};

export default ConceptItem;
