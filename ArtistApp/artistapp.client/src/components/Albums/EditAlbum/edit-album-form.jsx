import { useState, useEffect } from "react";
import { Form, Button, Container, Row, Col } from "react-bootstrap";
import { useNavigate, useParams } from "react-router";
import { requestUrl } from "../../../utils/utilServices";

const EditAlbumPage = () => {
  const navigate = useNavigate();
  const { id } = useParams();
  const [artist, setArtist] = useState({});
  const [formData, setFormData] = useState({
    id: 0,
    title: "",
    artistId: "",
    description: "",
    releaseYear: "",
  });
  useEffect(() => {
    getArtists();
  }, []);
  useEffect(() => {
    fetch(`${requestUrl}Album/GetAlbum?id=${id}`)
      .then((res) => res.json())
      .then((data) => {
        setFormData({
          id: data.id,
          title: data.title,
          artistId: data.artistId,
          releaseYear: data.releaseYear,
          description: data.description
        });
      })
      .catch((error) => {
        console.error("Error fetching album data:", error);
      });
  }, [id]);
  const getArtists = () => {
    fetch(`${requestUrl}Artist/GetArtists`, {
      method: "GET",
    })
      .then((res) => res.json())
      .then((data) => {
        setArtist(data);
      })
      .catch((error) => {
        console.error("Error uploading image:", error);
      });
  };
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    fetch(`${requestUrl}Album/UpdateAlbum`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData),
    })
      .then(() => {
        navigate("album");
      })
      .catch((error) => {
        console.error("Error updating album:", error);
      });
  };
  return (
    <Container>
      <Row>
        <Col md={6}>
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="title">
              <Form.Label>Title</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter title"
                name="title"
                value={formData.title}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="artistId">
              <Form.Label>Artist</Form.Label>
              <Form.Select
                name="artistId"
                value={formData.artistId}
                onChange={handleChange}
              >
                <option value="">Select Artist</option>
                {artist?.length > 0 &&
                  artist.map((item) => 
                    <option key={item.id} value={item.id}>{item.name}</option>
                  )
                }
              </Form.Select>
            </Form.Group>

            <Form.Group controlId="description">
              <Form.Label>Description</Form.Label>
              <Form.Control
                as="textarea"
                placeholder="Enter description"
                rows={3}
                name="description"
                value={formData.description}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="releaseYear">
              <Form.Label>Release Year</Form.Label>
              <Form.Control
                type="text"
                name="releaseYear"
                placeholder="Enter relase year"
                value={formData.releaseYear}
                onChange={handleChange}
              />
            </Form.Group>

            <Button variant="primary" type="submit" className="mt-3">
              Submit
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default EditAlbumPage;
