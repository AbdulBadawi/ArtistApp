import { useEffect, useState } from "react";
import { Form, Button, Container, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router";
import { requestUrl } from "../../../utils/utilServices";

const AddAlbumPage = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    title: "",
    artistId: "",
    description: "",
    releaseYear: "",
  });
  const [artist, setArtist] = useState({});
  useEffect(() => {
    getArtists();
  }, []);
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

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
  const handleSubmit = (e) => {
    e.preventDefault();

    fetch(`${requestUrl}Album/AddAlbum`, {
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
        console.error("Error uploading image:", error);
      });
  };

  return (
    <Container>
      <Row>
        <Col md={12}>
          <h3>Add Album </h3>
        </Col>
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

            <Form.Group controlId="artistId" >
              <Form.Label>Artist</Form.Label>
              <Form.Select
                name="artistId"
                value={formData.artistId}
                onChange={handleChange}
                required
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

export default AddAlbumPage;
