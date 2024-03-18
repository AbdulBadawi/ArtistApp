import { useEffect, useState } from "react";
import Card from "react-bootstrap/Card";
import { requestUrl } from "../../utils/utilServices";
import { useParams } from "react-router";

const ViewArtistAlbums = () => {
  const [artistAlbums, setArtistAlbums] = useState();
  const { id } = useParams();

  useEffect(() => {
    fetch(`${requestUrl}Artist/GetArtistWithAlbums?id=${id}`, {
      method: "GET",
    })
      .then((res) => res.json())
      .then((data) => {
        setArtistAlbums(data);
      })
      .catch((error) => {
        console.error("Error :", error);
      });
  }, [id]);
  return (
    <div>
      <div className="mb-3">
        <h3> {artistAlbums?.name} Albums </h3>
      </div>
      {artistAlbums?.albums?.length > 0 &&
        artistAlbums.albums.map((item, index) => (
          <Card key={index} style={{ width: "18rem" }}>
            <Card.Body>
              <Card.Title>{item.title}</Card.Title>
              <Card.Text>{item?.description}</Card.Text>
            </Card.Body>
          </Card>
        ))}
    </div>
  );
};

export default ViewArtistAlbums;
