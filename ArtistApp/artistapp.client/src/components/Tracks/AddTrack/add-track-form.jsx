import { useEffect, useState } from "react";
import { Form, Button, Container, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router";
import { requestUrl } from "../../../utils/utilServices";

const AddTrackPage = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    title: "",
    albumId: "",
    description: "",
  });
  const [album, setAlbum] = useState({});
  useEffect(() => {
    getAlbums();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const getAlbums = () => {
    fetch(`${requestUrl}Album/GetAlbums`, {
      method: "GET",
    })
      .then((res) => res.json())
      .then((data) => {
        setAlbum(data);
      })
      .catch((error) => {
        console.error("Error uploading image:", error);
      });
  };
  const handleSubmit = (e) => {
    e.preventDefault();

    fetch(`${requestUrl}Track/AddTrack`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData),
    })
      .then(() => {
        navigate("track");
      })
      .catch((error) => {
        console.error("Error uploading image:", error);
      });
  };

  return (
    <Container>
      <Row>
        <Col md={12}>
          <h3>Add Track </h3>
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

            <Form.Group controlId="albumId">
              <Form.Label>Album</Form.Label>
              <Form.Select
                name="albumId"
                value={formData.albumId}
                onChange={handleChange}
              >
                <option value="">Select album</option>
                {album?.length > 0 &&
                  album.map((item) => 
                  <option key={item.id} value={item.id}>{item.title}</option>
                )}
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

            <Button variant="primary" type="submit" className="mt-3">
              Submit
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default AddTrackPage;
